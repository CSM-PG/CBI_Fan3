﻿Module FanData
    ' This data is used by the fan selection logic. The values come from the original source files and its origin is never fully explained...
    ' It is believed that these values were obtained from a series of charts that were used in the '70s for efficiency/rpm calculations.

    ' Efficiency Table:
    '' 3 arrays of efficiency values, 1 for each type of fan. 118 values in each.
    Dim effi_t3 = New Double() {
        0.6, 0.6, 0.61, 0.61, 0.62, 0.62, 0.63, 0.63, 0.64, 0.64, 0.65, 0.65, 0.66, 0.66, 0.67, 0.67, 0.68, 0.68, 0.69, 0.69,
        0.7, 0.7, 0.71, 0.71, 0.72, 0.72, 0.73, 0.73, 0.74, 0.74, 0.75, 0.75, 0.76, 0.76, 0.76, 0.76, 0.76, 0.76, 0.77, 0.77,
        0.77, 0.77, 0.77, 0.77, 0.77, 0.77, 0.78, 0.78, 0.78, 0.78, 0.78, 0.78, 0.78, 0.78, 0.785, 0.785, 0.785, 0.785, 0.785,
        0.785, 0.785, 0.785, 0.785, 0.785, 0.78, 0.78, 0.78, 0.78, 0.78, 0.78, 0.78, 0.78, 0.77, 0.77, 0.77, 0.77, 0.77, 0.77,
        0.77, 0.77, 0.76, 0.76, 0.76, 0.76, 0.76, 0.76, 0.75, 0.75, 0.74, 0.74, 0.73, 0.73, 0.72, 0.72, 0.71, 0.71, 0.7, 0.7, 0.69,
        0.69, 0.68, 0.68, 0.67, 0.67, 0.66, 0.66, 0.65, 0.65, 0.64, 0.64, 0.63, 0.63, 0.62, 0.62, 0.61, 0.61, 0.6, 0.6
    }
    Dim effi_t4 = New Double() {
        0.6, 0.6, 0.61, 0.61, 0.62, 0.62, 0.63, 0.63, 0.64, 0.64, 0.65, 0.65, 0.66, 0.66, 0.67, 0.67, 0.68, 0.68, 0.69, 0.69,
        0.7, 0.7, 0.71, 0.71, 0.72, 0.72, 0.73, 0.73, 0.74, 0.74, 0.75, 0.75, 0.76, 0.76, 0.77, 0.77, 0.78, 0.78, 0.79, 0.8, 0.8,
        0.8, 0.8, 0.81, 0.81, 0.81, 0.81, 0.81, 0.81, 0.81, 0.81, 0.82, 0.82, 0.82, 0.82, 0.82, 0.82, 0.82, 0.82, 0.81, 0.81,
        0.81, 0.81, 0.81, 0.81, 0.8, 0.8, 0.8, 0.8, 0.79, 0.79, 0.78, 0.78, 0.78, 0.77, 0.77, 0.76, 0.75, 0.75, 0.74, 0.74, 0.73,
        0.73, 0.72, 0.72, 0.71, 0.71, 0.7, 0.69, 0.69, 0.68, 0.68, 0.67, 0.67, 0.66, 0.66, 0.65, 0.65, 0.64, 0.64, 0.63, 0.63,
        0.62, 0.62, 0.61, 0.61, 0.6, 0.6, 0.59, 0.59, 0.58, 0.58, 0.57, 0.57, 0.56, 0.56, 0.55, 0.55
    }
    Dim effi_t5 = New Double() {
        0.65, 0.65, 0.66, 0.66, 0.67, 0.67, 0.68, 0.68, 0.69, 0.69, 0.7, 0.7, 0.71, 0.71, 0.72, 0.72, 0.73, 0.73, 0.74, 0.74,
        0.75, 0.75, 0.76, 0.76, 0.77, 0.77, 0.77, 0.78, 0.78, 0.78, 0.78, 0.78, 0.79, 0.79, 0.79, 0.79, 0.79, 0.8, 0.8, 0.8,
        0.8, 0.8, 0.81, 0.81, 0.81, 0.81, 0.81, 0.81, 0.81, 0.81, 0.81, 0.81, 0.8, 0.8, 0.8, 0.8, 0.8, 0.79, 0.79, 0.79,
        0.79, 0.79, 0.78, 0.78, 0.78, 0.78, 0.78, 0.77, 0.77, 0.77, 0.76, 0.76, 0.75, 0.75, 0.74, 0.74, 0.73, 0.73, 0.72, 0.72,
        0.71, 0.71, 0.7, 0.7, 0.69, 0.69, 0.68, 0.68, 0.67, 0.67, 0.66, 0.66, 0.65, 0.65, 0.64, 0.64, 0.63, 0.63, 0.62, 0.62,
        0.61, 0.61, 0.6, 0.6, 0.59, 0.59, 0.58, 0.58, 0.57, 0.57, 0.56, 0.56, 0.55, 0.55, 0.54, 0.54, 0.53, 0.53
    }
    Public effi_table = New Dictionary(Of Integer, Double()) From {{3, effi_t3}, {4, effi_t4}, {5, effi_t5}}

    ' "Effsize" Table
    '' Perhaps stands for "effective size"... 3 arrays (one for each fan type) 118 entries each.
    Dim effsize_t3 = New Double() {
        -42.5, -42.0, -41.0, -40.3, -39.5, -38.7, -37.9, -37.0, -36.0, -35.0, -34.3, -33.7, -33.0, -32.2,
        -31.3, -30.7, -30.0, -29.1, -28.2, -27.5, -26.5, -25.3, -24.2, -23.0, -21.9, -20.9, -20.0, -19.0,
        -18.1, -17.0, -16.0, -14.9, -14.0, -13.7, -13.2, -13.0, -12.6, -12.2, -11.9, -11.7, -11.3, -11.0,
        -10.7, -10.3, -10.0, -9.7, -9.4, -9.0, -8.8, -8.3, -8.0, -7.7, -7.2, -6.9, -6.5, -6.1, -5.9, -5.5,
        -5.3, -5.1, -4.7, -4.1, -3.8, -3.2, -2.9, -2.5, -2.0, -1.6, -1.2, -0.8, -0.4, 0.0, 0.5, 1.0, 1.3, 1.8,
        2.2, 2.6, 3.0, 3.2, 3.6, 4.1, 4.5, 4.9, 5.3, 5.7, 6.9, 7.9, 8.8, 9.7, 10.1, 10.8, 11.3, 11.9, 12.6, 13.5,
        14.3, 15.1, 15.8, 16.2, 17.1, 17.8, 18.4, 19.1, 19.8, 20.3, 21.1, 21.8, 22.2, 23.0, 23.5, 24.2, 24.8,
        25.4, 26.0, 26.8, 27.3, 28.0
    }
    Dim effsize_t4 = New Double() {
        -41.5, -41.0, -40.1, -39.7, -39.0, -38.5, -37.5, -37.0, -36.0, -35.5, -34.3, -34.1, -33.6, -33.5,
        -32.1, -31.9, -31.0, -30.8, -30.0, -29.5, -28.1, -27.51, -26.92, -26.34, -25.76, -25.18, -24.6,
        -23.6, -22.65, -21.6, -20.7, -19.8, -18.9, -18.0, -17.1, -16.2, -15.3, -14.28, -13.25, -12.23,
        -11.2, -10.5, -9.8, -9.1, -8.4, -7.7, -7.0, -6.3, -5.6, -4.9, -4.2, -3.5, -2.8, -2.1, -1.4, -0.7,
        0.0, 0.375, 0.75, 1.125, 1.5, 1.85, 2.2, 2.55, 2.9, 3.55, 4.2, 5.0, 5.8, 6.4, 7.0, 7.6, 8.2, 9.46, 10.095,
        10.73, 11.36, 12.0, 12.69, 13.35, 14.03, 14.7, 15.05, 15.4, 15.75, 16.1, 16.45, 16.8, 18.5, 19.0,
        18.8, 20.1, 20.8, 21.0, 21.3, 21.7, 22.0, 22.5, 23.0, 24.5, 24.0, 24.3, 25.0, 26.0, 26.3, 26.5,
        27.0, 27.5, 28.0, 28.5, 28.9, 29.3, 29.9, 30.2, 30.5, 31.0, 31.0, 31.5
    }
    Dim effsize_t5 = New Double() {
        -37.7, -37.2, -36.5, -36.2, -35.5, -35.0, -34.2, -33.8, -32.9, -32.3, -31.5, -30.9, -30.2, -29.3,
        -28.6, -28.0, -27.2, -26.7, -26.0, -25.1, -24.2, -23.6, -22.8, -21.7, -21.0, -20.4, -19.8, -19.1,
        -18.5, -17.6, -17.4, -17.1, -16.3, -15.8, -15.2, -14.9, -14.6, -13.9, -13.4, -13.1, -12.4, -12.1,
        -11.6, -11.1, -10.7, -10.0, -9.5, -8.9, -8.7, -8.4, -8.1, -7.8, -7.2, -6.9, -6.6, -6.4, -6.1, -5.9,
        -5.3, -5.0, -4.8, -4.3, -3.7, -3.4, -3.0, -2.5, -2.0, -1.2, -0.1, 0.8, 1.7, 2.6, 3.9, 4.8, 5.4, 5.9,
        6.5, 7.0, 7.6, 8.0, 8.8, 9.2, 9.9, 10.6, 11.2, 11.9, 12.5, 12.8, 13.5, 14.1, 15.0, 15.4, 16.1, 16.9,
        17.6, 18.2, 18.9, 19.2, 19.8, 20.1, 20.4, 20.9, 21.6, 22.0, 22.4, 22.9, 23.2, 23.7, 24.2, 24.7,
        25.2, 25.9, 26.1, 27.0, 27.8, 28.2, 28.9, 29.7
    }
    Public effsize_table = New Dictionary(Of Integer, Double()) From {{3, effsize_t3}, {4, effsize_t4}, {5, effsize_t5}}

    ' "Effrpm" Table
    '' Perhaps stands for "effective rpm"... 3 arrays (one for each fan type) 118 entries each.
    Dim effrpm_t3 = New Double() {
        50.3, 49.9, 49.2, 48.7, 48.3, 47.6, 47.1, 46.5, 46.0, 45.2, 44.8, 44.3, 43.9, 43.4, 42.9, 42.3, 41.8,
        41.2, 40.6, 40.0, 39.3, 38.5, 37.8, 37.0, 36.0, 35.3, 34.6, 33.9, 33.2, 32.4, 31.7, 30.9, 30.0, 29.8,
        29.3, 29.0, 28.9, 28.7, 28.3, 28.1, 27.9, 27.7, 27.5, 27.1, 26.9, 26.7, 26.3, 26.0, 25.8, 25.5, 25.0,
        24.8, 24.5, 24.1, 23.9, 23.5, 23.2, 23.0, 22.8, 22.5, 22.3, 21.9, 21.5, 21.0, 20.7, 20.3, 20.0, 19.6,
        19.1, 18.7, 18.0, 17.4, 17.0, 16.8, 16.2, 15.9, 15.2, 15.0, 14.7, 14.4, 14.0, 13.7, 13.1, 12.7, 12.1,
        11.8, 11.0, 10.0, 9.0, 8.0, 7.2, 6.5, 5.9, 5.3, 4.4, 3.3, 2.3, 1.3, 0.7, 0.0, -1.0, -1.9, -2.7, -3.5, -4.1,
        -5.0, -5.9, -6.8, -7.4, -8.4, -9.0, -10.0, -10.8, -11.8, -12.4, -13.3, -14.1, -15.1
    }
    Dim effrpm_t4 = New Double() {
        59.8, 59.5, 59.2, 59.0, 58.2, 57.9, 57.5, 57.2, 56.5, 56.3, 55.8, 55.6, 55.1, 54.8, 54.5, 54.2, 53.8,
        53.5, 52.9, 52.5, 52.1, 51.7, 51.4, 51.05, 50.7, 50.35, 50.0, 49.43, 48.87, 48.18, 47.5, 46.92, 46.33,
        45.74, 45.16, 44.58, 44.0, 43.25, 42.5, 41.75, 41.0, 40.41, 39.81, 39.21, 38.62, 37.15, 36.85, 36.55,
        36.25, 35.65, 35.07, 34.47, 33.88, 33.28, 32.69, 32.1, 31.5, 31.125, 30.75, 30.36, 30.0, 29.62, 29.25,
        28.86, 28.5, 28.16, 27.81, 26.65, 25.5, 24.9, 24.3, 23.7, 23.1, 21.56, 20.89, 20.23, 19.65, 19.1, 18.35,
        17.6, 16.85, 16.1, 15.73, 15.36, 15.0, 14.63, 14.27, 13.9, 12.9, 12.5, 11.1, 10.9, 9.9, 9.8, 8.6, 8.5,
        7.5, 7.4, 6.5, 6.4, 5.2, 5.1, 4.0, 3.9, 2.0, 1.9, 0.0, 0.0, -0.7, -0.09, -1.5, -2.0, -2.5, -3.0, -3.5, -3.9,
        -4.5, -4.9
    }
    Dim effrpm_t5 = New Double() {
        65.2, 65.0, 64.8, 64.4, 64.2, 63.9, 63.5, 63.0, 62.6, 62.1, 61.7, 61.1, 60.9, 60.4, 59.9, 59.6, 59.0,
        58.7, 58.2, 57.8, 57.2, 56.7, 56.1, 55.5, 54.8, 54.4, 53.9, 53.7, 53.2, 52.8, 52.5, 52.1, 51.9, 51.4,
        50.9, 50.5, 50.1, 49.7, 49.4, 49.0, 48.6, 48.2, 48.0, 47.3, 47.0, 46.4, 45.9, 45.5, 45.3, 45.0, 44.8,
        44.5, 44.0, 43.9, 43.6, 43.4, 43.1, 42.9, 42.6, 42.2, 41.8, 41.5, 41.1, 40.9, 40.5, 40.0, 39.6, 38.8,
        37.6, 36.9, 35.9, 34.9, 33.6, 32.7, 32.2, 31.6, 31.0, 30.5, 29.9, 29.3, 28.7, 27.9, 27.3, 26.4, 25.9,
        25.2, 24.8, 24.1, 23.4, 22.6, 21.9, 21.1, 20.3, 19.6, 18.8, 17.9, 17.1, 16.6, 15.9, 15.5, 15.0, 14.5,
        13.9, 13.3, 12.8, 12.3, 11.9, 11.5, 10.4, 9.8, 9.2, 8.6, 8.0, 7.1, 6.6, 5.7, 4.8, 4.0
    }
    Public effrpm_table = New Dictionary(Of Integer, Double()) From {{3, effrpm_t3}, {4, effrpm_t4}, {5, effrpm_t5}}

    ' Max rpm table
    '' The maximum rpm rating for each fan size. 3 arrays w/ 21 values each.
    '' The OP had 5 leading zeros in each array...probably for fan sizes not available here at Clarke's...?
    '' UPDATE (Aug. 18, 2020): The max RPMs used in the OP were...weird. Max RPMs should be based on some fixed
    '' max tip speed (~100 m/s), but the OP max RPMs corresponded to wildly different tip speeds (like 70 to 120 m/s).
    '' The current max rpm values have been recalculated as of the date of this update. Tip speeds of 90, 100, and 110 m/s
    '' were used for the type 3, 4, and 5 fans, respectively.
    '' OLD VALUES:
    'Dim max_rpm_t3 = New Double() {5850, 5225, 4640, 4120, 3650, 3250, 2920, 2610, 2320, 2055, 1825, 1625, 1460, 1300, 1165, 1045, 915}
    'Dim max_rpm_t4 = New Double() {4822, 4330, 3820, 3389, 3000, 2673, 2406, 2148, 1906, 1696, 1500, 1336, 1200, 1070, 960, 860, 753}
    'Dim max_rpm_t5 = New Double() {4920, 4225, 3890, 3464, 3068, 2721, 2450, 2184, 1950, 1723, 1530, 1373, 1228, 1094, 980, 880, 770}
    '' NEW VALUES:
    Dim max_rpm_t3 = New Double() {4791, 4280, 3799, 3373, 2991, 2660, 2395, 2140, 1900, 1684, 1496, 1330, 1198, 1069, 966, 855, 749}
    Dim max_rpm_t4 = New Double() {4375, 3906, 3477, 3077, 2728, 2430, 2183, 1953, 1736, 1540, 1364, 1215, 1093, 977, 874, 781, 684}
    Dim max_rpm_t5 = New Double() {4136, 3697, 3292, 2915, 2595, 2306, 2068, 1853, 1644, 1461, 1297, 1152, 1035, 919, 828, 737, 648}


    Public max_rpm_table = New Dictionary(Of Integer, Double()) From {{3, max_rpm_t3}, {4, max_rpm_t4}, {5, max_rpm_t5}}

    ' Sizes (German)
    '' Fan sizes (diameter in mm?). 21 values. Like the max_rpm arrays, in the OP this had 5 leading zero values.
    Public sizes = New Double() {250, 280, 315, 355, 400, 450, 500, 560, 630, 710, 800, 900, 1000, 1120, 1250, 1400, 1600}

    ' Sizes (Clarke's)
    '' Fan sizes in Clarke's format (XX-Y where XX is (diameter in in.?) and Y is fan type.
    '' 3 arrays, 21 values each
    Dim clarke_sizes_t3 = New String() {"10-3", "11-3", "12-3", "14-3", "16-3", "18-3", "20-3", "22-3", "25-3", "28-3", "32-3", "36-3", "40-3", "44-3", "49-3", "55-3", "63-3"}
    Dim clarke_sizes_t4 = New String() {"10-4", "11-4", "12-4", "14-4", "16-4", "18-4", "20-4", "22-4", "25-4", "28-4", "32-4", "36-4", "40-4", "44-4", "49-4", "55-4", "63-4"}
    Dim clarke_sizes_t5 = New String() {"10-5", "11-5", "12-5", "14-5", "16-5", "18-5", "20-5", "22-5", "25-5", "28-5", "32-5", "36-5", "40-5", "44-5", "49-5", "55-5", "63-5"}
    Public clarke_size_table = New Dictionary(Of Integer, String()) From {{3, clarke_sizes_t3}, {4, clarke_sizes_t4}, {5, clarke_sizes_t5}}

    ' Transformation Matrix
    '' Used to transform intermediate pressure and flow into intermediate size and rpm
    '' OP used the transpose of this matrix, but with the equivalent calculation performed in this program
    Public trans_matrix = {{-0.4451612, 0.8974576}, {0.8314773, -0.5632478}}

    ' Fan Types
    Public fan_types = New Integer() {3, 4, 5}
End Module