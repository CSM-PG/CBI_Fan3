Module FanCalculations

    Dim METER_PER_FOOT As Double = 0.3048
    Dim KM_PER_FOOT As Double = METER_PER_FOOT / 1000
    Dim MM_PER_INCH As Double = 25.4
    Dim SEC_PER_MIN As Double = 60
    Dim KW_PER_HP As Double = 0.7457
    Dim SHAFT_TO_MOTOR As Double = 1.05


    Function indexOfClosest(val As Double, ls As Double()) As Integer
        ' Return the index of the element of ls which is closest in value to val
        ' If multiple items in the list are the same distance from val, the first is returned
        ' Throws exception on empty ls
        If ls.Length = 0 Then
            Throw New Exception("Empty list encountered in ""index_of_closest"" ")
        End If
        Dim closest = Double.MaxValue
        Dim closest_index As Integer = 0
        Dim i As Integer = 0
        For Each x In ls
            If Math.Abs(x - val) < closest Then
                closest = Math.Abs(x - val)
                closest_index = i
            End If
            i += 1
        Next
        Return closest_index
    End Function

    Function elevationCorrection(elev As Double) As Double
        '
        Dim L As Double = 6.5 'atmospheric temp lapse rate (K/km)
        Dim g As Double = 9.8 'acc. due to gravity (m/s^2)
        Dim M As Double = 0.02896 'Molar mass of dry air (kg/mol)
        Dim R As Double = 8.314 'Gas constant (J/mol K)
        Dim T0 As Double = 293.3 'Stnadard Temp (K)
        Dim exponent As Double = (g * M) / (R * L)

        Return (1 - L * KM_PER_FOOT * elev / T0) ^ exponent
    End Function

    Function elevation_correction(elev As Double) As Double
        ' Return a correction factor for the input elevation.
        ' Apparently the numbers in the function came from a least-squares fit preformed on some emperical data...
        ' From a physics perspective, I can't understand why this particular functional form was used for the fit...
        ' BUT this seems to be what the original program used, so... here it is.... ... ... .. . .. . . . .
        Select Case elev
            Case Is < 2000
                Return 29.92 / ((elev / -953.738) + 29.9084)
            Case 2000 To 4000
                Return 29.92 / ((elev / -1009.06) + 29.794)
            Case 4000 To 6000
                Return 29.92 / ((elev / -1076.67) + 29.5438)
            Case 6000 To 10000
                Return 29.92 / ((elev / -1186.44) + 28.9836)
            Case Else
                Return 29.92 / ((elev / -2212.67) + 22.9634)
        End Select
    End Function

    Function temperature_correction(temp As Double) As Double
        ' Return a correction factor for the input temperature (in Fahrenheit!!)
        ' Agian, I have NO idea where these numbers come from, but they were used in the original program
        Return (temp + 460) / 530
    End Function

    Function temperatureCorrection(temp As Double) As Double
        Return (temp + 460) / 530
    End Function

    Function rarefaction(pressure As Double) As Double
        ' Return some sort of rarefaction correction for the input pressure
        ' Ok, I have absolutely no ideas on this one either... it's just what the OP used, OK?!
        Return 408 / (408 - pressure)
    End Function

    Function suggest_fans(isp As Double, dsp As Double, flow As Double, minT As Double, maxT As Double, elev As Double) As List(Of String())
        ' Suggest fans based on the actual required condtions. This is basically the core of the program.
        ' As a physicist by training, this author cannot speak to the physical validity of the "correction" factors used herein.
        ' Inputs:
        '' isp: Inlet static pressure (in.WC)
        '' dsp: Discharge static pressure (in.WC)
        '' minT: Min operating temperature (deg. F)
        '' maxT: Max operating temperature (deg. F)
        '' elev: The elevation the fan will operate at (ft. above sea level) 
        '' flow: The required flowrate for the fan (cu. ft. / min)

        ' Correction factors for high/low temp
        Dim lt_factor = elevation_correction(elev) * temperature_correction(minT)
        Dim ht_factor = elevation_correction(elev) * temperature_correction(maxT)
        Dim r_factor = rarefaction(isp)

        ' Apply correction factors to get equivalent values at standard conditions
        ' --Some of these are kinda weird and redundent, but it's what the OP did.
        Dim std_isp = isp * ht_factor * r_factor
        Dim std_tsp = (isp + dsp) * ht_factor * r_factor
        Dim lt_tsp = std_tsp / (lt_factor * r_factor)
        Dim ht_tsp = std_tsp / (ht_factor * r_factor) ' This is just the uncorrected TSP!!! WHY??

        ' Convert to metric (MKS)
        Dim flow_mks = flow * METER_PER_FOOT ^ 3 / SEC_PER_MIN
        Dim tsp_mks = std_tsp * MM_PER_INCH

        ' Convert to intermediate values
        ' --These numbers come directly from the OP. It is believed that they are an artifact of the
        '   logarithmic charts that the fan data origianlly came from...
        Dim tsp_int = -193.5 + 99.1 * Math.Log10(tsp_mks)
        Dim flow_int = -12.4666666666667 + 98.95 * Math.Log10(flow_mks)
        Dim size_int = FanData.trans_matrix(0, 0) * tsp_int + FanData.trans_matrix(0, 1) * flow_int
        Dim rpm_int = FanData.trans_matrix(1, 0) * tsp_int + FanData.trans_matrix(1, 1) * flow_int

        ' Go through fans to find closest matches to desired parameters
        Dim results As New List(Of String())
        For Each fan_type In fan_types

            ' Get the effsizes for this type
            Dim effsizes As Double() = FanData.effsize_table(fan_type)

            ' Find min/max effsize for this fan type
            Dim min_effsize = effsizes.Min()
            Dim max_effsize = effsizes.Max()

            ' Loop through fans of this type
            For size_index As Integer = 0 To FanData.sizes.Length - 1
                ' Get the sizes
                Dim current_size = FanData.sizes(size_index)
                Dim clarke_size = FanData.clarke_size_table(fan_type)(size_index)

                ' Caluclate size "offset"
                ' --This is another weird thing that the OP does
                Dim offset = size_int - (176.748382493078 * Math.Log10(current_size) - 459.660165043038)

                ' Continue to next size if this one is no good
                If (offset < min_effsize) Or (offset > max_effsize) Then
                    Continue For
                End If

                ' Find index of value in effsize table the is closest to offset
                Dim closest_index = indexOfClosest(offset, effsizes)

                ' Calculate necessary rpm for this fan, get max rpm, then compare
                Dim rpm_offset = rpm_int - FanData.effrpm_table(fan_type)(closest_index)
                Dim rpm_real = 10 ^ ((rpm_offset + 361.355925512951) / 109.457530726539) ' weird mystery numbers from OP
                Dim max_rpm = FanData.max_rpm_table(fan_type)(size_index)
                If Double.IsNaN(rpm_real) Then ' Continue to next size: bad rpm!
                    Continue For
                End If
                If rpm_real > max_rpm Then ' Continue to next size: fan is no good!
                    Continue For
                End If

                ' Get the efficiency
                Dim eff = effi_table(fan_type)(closest_index)

                ' Calculate min/max shaft HP and motor HP
                ' --high HP comes from low pressure and vice versa
                ' --again, these numbers come inexplicably from the OP
                Dim low_hp = (flow * ht_tsp) / (6354 * eff)
                Dim high_hp = (flow * lt_tsp) / (6354 * eff)
                Dim motor_hp = high_hp * SHAFT_TO_MOTOR

                ' Calculate noise estimate
                ' --This is an adaptation of what's in the OP.
                ' --The equation has been slightly altered to hopefully make it more accurate
                Dim noise = 50 + 10 * Math.Log10(motor_hp * KW_PER_HP) + 10 * Math.Log10(tsp_mks)

                ' Stringify and Organize output data
                Dim eff_str As String = Format(eff, "0.0%")
                Dim size_str As String = clarke_size
                Dim rpm_str As String = Str(Int(rpm_real))
                Dim max_rpm_str As String = Str(Int(max_rpm))
                Dim low_hp_str As String = Format(low_hp, "0.0")
                Dim high_hp_str As String = Format(high_hp, "0.0")
                Dim motor_hp_str As String = Format(motor_hp, "0.0")
                Dim noise_str As String = Format(noise, "0.0")

                Dim result_arr As String() = {eff_str, size_str, rpm_str, max_rpm_str, low_hp_str, high_hp_str, motor_hp_str, noise_str}
                results.Add(result_arr)
            Next
        Next
        Return results
    End Function

    Function suggestFans(inputs As Double(), correctPressure As Boolean, correctFlow As Boolean) As List(Of String())
        ' Extract inputs
        Dim isp, dsp, flow, minT, maxT, elev
        isp = inputs(0)
        dsp = inputs(1)
        flow = inputs(2)
        minT = inputs(3)
        maxT = inputs(4)
        elev = inputs(5)

        Dim lt_factor = temperature_correction(minT) / elevationCorrection(elev)
        Dim ht_factor = temperature_correction(maxT) / elevationCorrection(elev)

        Dim tsp = isp + dsp
        Dim lt_tsp, ht_tsp
        If correctPressure Then
            lt_tsp = tsp * lt_factor
            ht_tsp = tsp * ht_factor
        Else
            lt_tsp = tsp
            ht_tsp = tsp
        End If

        Dim lt_flow, ht_flow
        If correctFlow Then
            lt_flow = flow * lt_factor
            ht_flow = flow * ht_factor
        Else
            lt_flow = flow
            ht_flow = flow
        End If

        ' Conver to metric
        Dim lt_flow_mks = lt_flow * METER_PER_FOOT ^ 3 / SEC_PER_MIN
        Dim ht_flow_mks = ht_flow * METER_PER_FOOT ^ 3 / SEC_PER_MIN
        Dim lt_tsp_mks = lt_tsp * MM_PER_INCH
        Dim ht_tsp_mks = ht_tsp * MM_PER_INCH

        ' Convert to intermediate
        Dim lt_tsp_int = -193.5 + 99.1 * Math.Log10(lt_tsp_mks)
        Dim ht_tsp_int = -193.5 + 99.1 * Math.Log10(ht_tsp_mks)
        Dim lt_flow_int = -12.4666666666667 + 98.95 * Math.Log10(lt_flow_mks)
        Dim ht_flow_int = -12.4666666666667 + 98.95 * Math.Log10(ht_flow_mks)
        Dim size_int = FanData.trans_matrix(0, 0) * ht_tsp_int + FanData.trans_matrix(0, 1) * ht_flow_int
        Dim rpm_int = FanData.trans_matrix(1, 0) * ht_tsp_int + FanData.trans_matrix(1, 1) * ht_flow_int

        ' Go through fans to find closest matches to desired parameters
        Dim results As New List(Of String())
        For Each fan_type In fan_types

            ' Get the effsizes for this type
            Dim effsizes As Double() = FanData.effsize_table(fan_type)

            ' Find min/max effsize for this fan type
            Dim min_effsize = effsizes.Min()
            Dim max_effsize = effsizes.Max()

            ' Loop through fans of this type
            For size_index As Integer = 0 To FanData.sizes.Length - 1
                ' Get the sizes
                Dim current_size = FanData.sizes(size_index)
                Dim clarke_size = FanData.clarke_size_table(fan_type)(size_index)

                ' Caluclate size "offset"
                ' --This is another weird thing that the OP does
                Dim offset = size_int - (176.748382493078 * Math.Log10(current_size) - 459.660165043038)

                ' Continue to next size if this one is no good
                If (offset < min_effsize) Or (offset > max_effsize) Then
                    Continue For
                End If

                ' Find index of value in effsize table the is closest to offset
                Dim closest_index = indexOfClosest(offset, effsizes)

                ' Calculate necessary rpm for this fan, get max rpm, then compare
                Dim rpm_offset = rpm_int - FanData.effrpm_table(fan_type)(closest_index)
                Dim rpm_real = 10 ^ ((rpm_offset + 361.355925512951) / 109.457530726539) ' weird mystery numbers from OP
                Dim max_rpm = FanData.max_rpm_table(fan_type)(size_index)
                If Double.IsNaN(rpm_real) Then ' Continue to next size: bad rpm!
                    Continue For
                End If
                If rpm_real > max_rpm Then ' Continue to next size: fan is no good!
                    Continue For
                End If

                ' Get the efficiency
                Dim eff = effi_table(fan_type)(closest_index)

                ' Calculate min/max shaft HP and motor HP
                ' --high HP comes from low pressure and vice versa
                ' --again, these numbers come inexplicably from the OP
                Dim low_hp = (lt_flow * lt_tsp) / (6354 * eff)
                Dim high_hp = (ht_flow * ht_tsp) / (6354 * eff)
                Dim motor_hp = high_hp * SHAFT_TO_MOTOR

                ' Calculate noise estimate
                ' --This is an adaptation of what's in the OP.
                ' --The equation has been slightly altered to hopefully make it more accurate
                Dim noise = 50 + 10 * Math.Log10(motor_hp * KW_PER_HP) + 10 * Math.Log10(ht_tsp_mks)

                ' Stringify and Organize output data
                Dim eff_str As String = Format(eff, "0.0%")
                Dim size_str As String = clarke_size
                Dim rpm_str As String = Str(Int(rpm_real))
                Dim max_rpm_str As String = Str(Int(max_rpm))
                Dim low_hp_str As String = Format(low_hp, "0.0")
                Dim high_hp_str As String = Format(high_hp, "0.0")
                Dim motor_hp_str As String = Format(motor_hp, "0.0")
                Dim noise_str As String = Format(noise, "0.0")

                Dim result_arr As String() = {eff_str, size_str, rpm_str, max_rpm_str, low_hp_str, high_hp_str, motor_hp_str, noise_str}
                results.Add(result_arr)
            Next
        Next
        Return results
    End Function

    Public Function correctedPressure(pressure, maxT, elev)
        Return pressure * temperatureCorrection(maxT) / elevationCorrection(elev)
    End Function

    Public Function correctedFlow(flow, maxT, elev)
        Return flow * temperatureCorrection(maxT) / elevationCorrection(elev)
    End Function

End Module
