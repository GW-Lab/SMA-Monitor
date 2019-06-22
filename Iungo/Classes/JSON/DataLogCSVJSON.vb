﻿' Program..: DataLogCSVJSON.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB16.1.3 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: Type Class (DataLogCSVJSON)
Imports Newtonsoft.Json
Public Class DataLogCSVJSON
   Public Ok As Boolean
   Public [Type] As String
   Public Time As UInteger
   Public [Error] As String
   Public Systime As UInteger
   Public rv As New RVValues
   Public Class RVValues
      Public Data As List(Of List(Of Single))
   End Class
   Public Function ToJsonString() As String
      Return JsonConvert.SerializeObject(Me)
   End Function
End Class

'{"ok"true,"type":"response","time":0.075441607987159,"rv":{"data":
'[[1510339642,0],[1510339643,0],[1510339644,0],[1510339645,0],[1510339646,0],[1510339647,0],[1510339648,0],
'[1510339649,0],[1510339650,0],[1510339651,0],[1510339652,0],[1510339653,0],[1510339654,0],[1510339655,0],
'[1510339656,0],[1510339657,0],[1510339658,0],[1510339659,0],[1510339660,0],[1510339661,0],[1510339662,0],
'[1510339663,0],[1510339664,0],[1510339665,0],[1510339666,0],[1510339667,0],[1510339668,0],[1510339669,0],
'[1510339670,0],[1510339671,0],[1510339672,0],[1510339673,0],[1510339674,0],[1510339675,0],[1510339676,0],
'[1510339677,0],[1510339678,0],[1510339679,0],[1510339680,0],[1510339681,0],[1510339682,0],[1510339683,0],
'[1510339684,0],[1510339685,0],[1510339686,0],[1510339687,0],[1510339688,0],[1510339689,0],[1510339690,0],
'[1510339691,0],[1510339692,0],[1510339693,0],[1510339694,0],[1510339695,0],[1510339696,0],[1510339697,0],
'[1510339698,0],[1510339699,0],[1510339700,0],[1510339701,0],[1510339702,0],[1510339703,0],[1510339704,0],
'[1510339705,0],[1510339706,0],[1510339707,0],[1510339708,0],[1510339709,0],[1510339710,0],[1510339711,0],
'[1510339712,0],[1510339713,0],[1510339714,0],[1510339715,0],[1510339716,0],[1510339717,0],[1510339718,0],
'[1510339719,0],[1510339720,0],[1510339721,0],[1510339722,0],[1510339723,0],[1510339724,0],[1510339725,0],
'[1510339726,0],[1510339727,0],[1510339728,0],[1510339729,0],[1510339730,0],[1510339731,0],[1510339732,0],
'[1510339733,0],[1510339734,0],[1510339735,0],[1510339736,0],[1510339737,0],[1510339738,0],[1510339739,0],
'[1510339740,0],[1510339741,0],[1510339742,0],[1510339743,0],[1510339744,0],[1510339745,0],[1510339746,0],
'[1510339747,0],[1510339748,0],[1510339749,0],[1510339750,0],[1510339751,0],[1510339752,0],[1510339753,0],
'[1510339754,0],[1510339755,0],[1510339756,0],[1510339757,0],[1510339758,0],[1510339759,0],[1510339760,0],
'[1510339761,0],[1510339762,0],[1510339763,0],[1510339764,0],[1510339765,0],[1510339766,0],[1510339767,0],
'[1510339768,0],[1510339769,0],[1510339770,0],[1510339771,0],[1510339772,0],[1510339773,0],[1510339774,0],
'[1510339775,0],[1510339776,0],[1510339777,0],[1510339778,0],[1510339779,0],[1510339780,0],[1510339781,0],
'[1510339782,0],[1510339783,0],[1510339784,0],[1510339785,0],[1510339786,0],[1510339787,0],[1510339788,0],
'[1510339789,0],[1510339790,0],[1510339791,0],[1510339792,0],[1510339793,0],[1510339794,0],[1510339795,0],
'[1510339796,0],[1510339797,0],[1510339798,0],[1510339799,0],[1510339800,0],[1510339801,0],[1510339802,0],
'[1510339803,0],[1510339804,0],[1510339805,0],[1510339806,0],[1510339807,0],[1510339808,0],[1510339809,0],
'[1510339810,0],[1510339811,0],[1510339812,0],[1510339813,0],[1510339814,0],[1510339815,0],[1510339816,0],
'[1510339817,0],[1510339818,0],[1510339819,0],[1510339820,0],[1510339821,0],[1510339822,0],[1510339823,0],
'[1510339824,0],[1510339825,0],[1510339826,0],[1510339827,0],[1510339828,0],[1510339829,0],[1510339830,0],
'[1510339831,0],[1510339832,0],[1510339833,0],[1510339834,0],[1510339835,0],[1510339836,0],[1510339837,0],
'[1510339838,0],[1510339839,0],[1510339840,0],[1510339841,0],[1510339842,0],[1510339843,0],[1510339844,0],
'[1510339845,0],[1510339846,0],[1510339847,0],[1510339848,0],[1510339849,0],[1510339850,0],[1510339851,0],
'[1510339852,0],[1510339853,0],[1510339854,0],[1510339855,0],[1510339856,0],[1510339857,0],[1510339858,0],
'[1510339859,0],[1510339860,0],[1510339861,0],[1510339862,0],[1510339863,0],[1510339864,0],[1510339865,0],
'[1510339866,0],[1510339867,0],[1510339868,0],[1510339869,0],[1510339870,0],[1510339871,0],[1510339872,0],
'[1510339873,0],[1510339874,0],[1510339875,0],[1510339876,0],[1510339877,0],[1510339878,0],[1510339879,0],
'[1510339880,0],[1510339881,0],[1510339882,0],[1510339883,0],[1510339884,0],[1510339885,0],[1510339886,0],
'[1510339887,0],[1510339888,0],[1510339889,0],[1510339890,0],[1510339891,0],[1510339892,0],[1510339893,0],
'[1510339894,0],[1510339895,0],[1510339896,0],[1510339897,0],[1510339898,0],[1510339899,0],[1510339900,0],
'[1510339901,0],[1510339902,0],[1510339903,0],[1510339904,0],[1510339905,0],[1510339906,0],[1510339907,0],
'[1510339908,0],[1510339909,0],[1510339910,0],[1510339911,0],[1510339912,0],[1510339913,0],[1510339914,0],
'[1510339915,0],[1510339916,0],[1510339917,0],[1510339918,0],[1510339919,0],[1510339920,0],[1510339921,0],
'[1510339922,0],[1510339923,0],[1510339924,0],[1510339925,0],[1510339926,0],[1510339927,0],[1510339928,0],
'[1510339929,0],[1510339930,0],[1510339931,0],[1510339932,0],[1510339933,0],[1510339934,0],[1510339935,0],
'[1510339936,0],[1510339937,0],[1510339938,0],[1510339939,0],[1510339940,0],[1510339941,0],[1510339942,0],
'[1510339943,0],[1510339944,0],[1510339945,0],[1510339946,0],[1510339947,0],[1510339948,0],[1510339949,0],
'[1510339950,0],[1510339951,0],[1510339952,0],[1510339953,0],[1510339954,0],[1510339955,0],[1510339956,0],
'[1510339957,0],[1510339958,0],[1510339959,0],[1510339960,0],[1510339961,0],[1510339962,0],[1510339963,0],
'[1510339964,0],[1510339965,0],[1510339966,0],[1510339967,0],[1510339968,0],[1510339969,0],[1510339970,0],
'[1510339971,0],[1510339972,0],[1510339973,0],[1510339974,0],[1510339975,0],[1510339976,0],[1510339977,0],
'[1510339978,0],[1510339979,0],[1510339980,0],[1510339981,0],[1510339982,0],[1510339983,0],[1510339984,0],
'[1510339985,0],[1510339986,0],[1510339987,0],[1510339988,0],[1510339989,0],[1510339990,0],[1510339991,0],
'[1510339992,0],[1510339993,0],[1510339994,0],[1510339995,0],[1510339996,0],[1510339997,0],[1510339998,0],
'[1510339999,0],[1510340000,0],[1510340001,0],[1510340002,0],[1510340003,0],[1510340004,0],[1510340005,0],
'[1510340006,0],[1510340007,0],[1510340008,0],[1510340009,0],[1510340010,0],[1510340011,0],[1510340012,0],
'[1510340013,0],[1510340014,0],[1510340015,0],[1510340016,0],[1510340017,0],[1510340018,0],[1510340019,0],
'[1510340020,0],[1510340021,0],[1510340022,0],[1510340023,0],[1510340024,0],[1510340025,0],[1510340026,0],
'[1510340027,0],[1510340028,0],[1510340029,0],[1510340030,0],[1510340031,0],[1510340032,0],[1510340033,0],
'[1510340034,0],[1510340035,0],[1510340036,0],[1510340037,0],[1510340038,0],[1510340039,0],[1510340040,0],
'[1510340041,0],[1510340042,0],[1510340043,0],[1510340044,0],[1510340045,0],[1510340046,0],[1510340047,0],
'[1510340048,0],[1510340049,0],[1510340050,0],[1510340051,0],[1510340052,0],[1510340053,0],[1510340054,0],
'[1510340055,0],[1510340056,0],[1510340057,0],[1510340058,0],[1510340059,0],[1510340060,0],[1510340061,0],
'[1510340062,0],[1510340063,0],[1510340064,0],[1510340065,0],[1510340066,0],[1510340067,0],[1510340068,0],
'[1510340069,0],[1510340070,0],[1510340071,0],[1510340072,0],[1510340073,0],[1510340074,0],[1510340075,0],
'[1510340076,0],[1510340077,0],[1510340078,0],[1510340079,0],[1510340080,0],[1510340081,0],[1510340082,0],
'[1510340083,0],[1510340084,0],[1510340085,0],[1510340086,0],[1510340087,0],[1510340088,0],[1510340089,0],
'[1510340090,0],[1510340091,0],[1510340092,0],[1510340093,0],[1510340094,0],[1510340095,0],[1510340096,0],
'[1510340097,0],[1510340098,0],[1510340099,0],[1510340100,0],[1510340101,0],[1510340102,0],[1510340103,0],
'[1510340104,0],[1510340105,0],[1510340106,0],[1510340107,0],[1510340108,0],[1510340109,0],[1510340110,0],
'[1510340111,0],[1510340112,0],[1510340113,0],[1510340114,0],[1510340115,0],[1510340116,0],[1510340117,0],
'[1510340118,0],[1510340119,0],[1510340120,0],[1510340121,0],[1510340122,0],[1510340123,0],[1510340124,0],
'[1510340125,0],[1510340126,0],[1510340127,0],[1510340128,0],[1510340129,0],[1510340130,0],[1510340131,0],
'[1510340132,0],[1510340133,0],[1510340134,0],[1510340135,0],[1510340136,0],[1510340137,0],[1510340138,0],
'[1510340139,0],[1510340140,0],[1510340141,0],[1510340142,0],[1510340143,0],[1510340144,0],[1510340145,0],
'[1510340146,0],[1510340147,0],[1510340148,0],[1510340149,0],[1510340150,0],[1510340151,0],[1510340152,0],
'[1510340153,0],[1510340154,0],[1510340155,0],[1510340156,0],[1510340157,0],[1510340158,0],[1510340159,0],
'[1510340160,0],[1510340161,0],[1510340162,0],[1510340163,0],[1510340164,0],[1510340165,0],[1510340166,0],
'[1510340167,0],[1510340168,0],[1510340169,0],[1510340170,0],[1510340171,0],[1510340172,0],[1510340173,0],
'[1510340174,0],[1510340175,0],[1510340176,0],[1510340177,0],[1510340178,0],[1510340179,0],[1510340180,0],
'[1510340181,0],[1510340182,0],[1510340183,0],[1510340184,0],[1510340185,0],[1510340186,0],[1510340187,0],
'[1510340188,0],[1510340189,0],[1510340190,0],[1510340191,0],[1510340192,0],[1510340193,0],[1510340194,0],
'[1510340195,0],[1510340196,0],[1510340197,0],[1510340198,0],[1510340199,0],[1510340200,0],[1510340201,0],
'[1510340202,0],[1510340203,0],[1510340204,0],[1510340205,0],[1510340206,0],[1510340207,0],[1510340208,0],
'[1510340209,0],[1510340210,0],[1510340211,0],[1510340212,0],[1510340213,0],[1510340214,0],[1510340215,0],
'[1510340216,0],[1510340217,0],[1510340218,0],[1510340219,0],[1510340220,0],[1510340221,0],[1510340222,0],
'[1510340223,0],[1510340224,0],[1510340225,0],[1510340226,0],[1510340227,0],[1510340228,0],[1510340229,0],
'[1510340230,0],[1510340231,0],[1510340232,0],[1510340233,0],[1510340234,0],[1510340235,0],[1510340236,0],
'[1510340237,0],[1510340238,0],[1510340239,0],[1510340240,0],[1510340241,0],[1510340242,0],[1510340243,0],
'[1510340244,0],[1510340245,0],[1510340246,0],[1510340247,0],[1510340248,0],[1510340249,0],[1510340250,0],
'[1510340251,0],[1510340252,0],[1510340253,0],[1510340254,0],[1510340255,0],[1510340256,0],[1510340257,0],
'[1510340258,0],[1510340259,0],[1510340260,0],[1510340261,0],[1510340262,0],[1510340263,0],[1510340264,0],
'[1510340265,0],[1510340266,0],[1510340267,0],[1510340268,0],[1510340269,0],[1510340270,0],[1510340271,0],
'[1510340272,0],[1510340273,0],[1510340274,0],[1510340275,0],[1510340276,0],[1510340277,0],[1510340278,0],
'[1510340279,0],[1510340280,0],[1510340281,0],[1510340282,0],[1510340283,0],[1510340284,0],[1510340285,0],
'[1510340286,0],[1510340287,0],[1510340288,0],[1510340289,0],[1510340290,0],[1510340291,0],[1510340292,0],
'[1510340293,0],[1510340294,0],[1510340295,0],[1510340296,0],[1510340297,0],[1510340298,0],[1510340299,0],
'[1510340300,0],[1510340301,0],[1510340302,0],[1510340303,0],[1510340304,0],[1510340305,0],[1510340306,0],
'[1510340307,0],[1510340308,0],[1510340309,0],[1510340310,0],[1510340311,0],[1510340312,0],[1510340313,0],
'[1510340314,0],[1510340315,0],[1510340316,0],[1510340317,0],[1510340318,0],[1510340319,0],[1510340320,0],
'[1510340321,0],[1510340322,0],[1510340323,0],[1510340324,0],[1510340325,0],[1510340326,0],[1510340327,0],
'[1510340328,0],[1510340329,0],[1510340330,0],[1510340331,0],[1510340332,0],[1510340333,0],[1510340334,0],
'[1510340335,0],[1510340336,0],[1510340337,0],[1510340338,0],[1510340339,0],[1510340340,0],[1510340341,0],
'[1510340342,0],[1510340343,0],[1510340344,0],[1510340345,0],[1510340346,0],[1510340347,0],[1510340348,0],
'[1510340349,0],[1510340350,0],[1510340351,0],[1510340352,0],[1510340353,0],[1510340354,0],[1510340355,0],
'[1510340356,0],[1510340357,0],[1510340358,0],[1510340359,0],[1510340360,0],[1510340361,0],[1510340362,0],
'[1510340363,0],[1510340364,0],[1510340365,0],[1510340366,0],[1510340367,0],[1510340368,0],[1510340369,0],
'[1510340370,0],[1510340371,0],[1510340372,0],[1510340373,0],[1510340374,0],[1510340375,0],[1510340376,0],
'[1510340377,0],[1510340378,0],[1510340379,0],[1510340380,0],[1510340381,0],[1510340382,0],[1510340383,0],
'[1510340384,0],[1510340385,0],[1510340386,0],[1510340387,0],[1510340388,0],[1510340389,0],[1510340390,0],
'[1510340391,0],[1510340392,0],[1510340393,0],[1510340394,0],[1510340395,0],[1510340396,0],[1510340397,0],
'[1510340398,0],[1510340399,0],[1510340400,0],[1510340401,0],[1510340402,0],[1510340403,0],[1510340404,0],
'[1510340405,0],[1510340406,0],[1510340407,0],[1510340408,0],[1510340409,0],[1510340410,0],[1510340411,0],
'[1510340412,0],[1510340413,0],[1510340414,0],[1510340415,0],[1510340416,0],[1510340417,0],[1510340418,0],
'[1510340419,0],[1510340420,0],[1510340421,0],[1510340422,0],[1510340423,0],[1510340424,0],[1510340425,0],
'[1510340426,0],[1510340427,0],[1510340428,0],[1510340429,0],[1510340430,0],[1510340431,0],[1510340432,0],
'[1510340433,0],[1510340434,0],[1510340435,0],[1510340436,0],[1510340437,0],[1510340438,0],[1510340439,0],
'[1510340440,0],[1510340441,0],[1510340442,0],[1510340443,0],[1510340444,0],[1510340445,0],[1510340446,0],
'[1510340447,0],[1510340448,0],[1510340449,0],[1510340450,0],[1510340451,0],[1510340452,0],[1510340453,0],
'[1510340454,0],[1510340455,0],[1510340456,0],[1510340457,0],[1510340458,0],[1510340459,0],[1510340460,0],
'[1510340461,0],[1510340462,0],[1510340463,0],[1510340464,0],[1510340465,0],[1510340466,0],[1510340467,0],
'[1510340468,0],[1510340469,0],[1510340470,0],[1510340471,0],[1510340472,0],[1510340473,0],[1510340474,0],
'[1510340475,0],[1510340476,0],[1510340477,0],[1510340478,0],[1510340479,0],[1510340480,0],[1510340481,0],
'[1510340482,0],[1510340483,0],[1510340484,0],[1510340485,0],[1510340486,0],[1510340487,0],[1510340488,0],
'[1510340489,0],[1510340490,0],[1510340491,0],[1510340492,0],[1510340493,0],[1510340494,0],[1510340495,0],
'[1510340496,0],[1510340497,0],[1510340498,0],[1510340499,0],[1510340500,0],[1510340501,0],[1510340502,0],
'[1510340503,0],[1510340504,0],[1510340505,0],[1510340506,0],[1510340507,0],[1510340508,0],[1510340509,0],
'[1510340510,0],[1510340511,0],[1510340512,0],[1510340513,0],[1510340514,0],[1510340515,0],[1510340516,0],
'[1510340517,0],[1510340518,0],[1510340519,0],[1510340520,0],[1510340521,0],[1510340522,0],[1510340523,0],
'[1510340524,0],[1510340525,0],[1510340526,0],[1510340527,0],[1510340528,0],[1510340529,0],[1510340530,0],
'[1510340531,0],[1510340532,0],[1510340533,0],[1510340534,0],[1510340535,0],[1510340536,0],[1510340537,0],
'[1510340538,0],[1510340539,0],[1510340540,0],[1510340541,0],[1510340542,0],[1510340543,0],[1510340544,0],
'[1510340545,0],[1510340546,0],[1510340547,0],[1510340548,0],[1510340549,0],[1510340550,0],[1510340551,0],
'[1510340552,0],[1510340553,0],[1510340554,0],[1510340555,0],[1510340556,0],[1510340557,0],[1510340558,0],
'[1510340559,0],[1510340560,0],[1510340561,0],[1510340562,0],[1510340563,0],[1510340564,0],[1510340565,0],
'[1510340566,0],[1510340567,0],[1510340568,0],[1510340569,0],[1510340570,0],[1510340571,0],[1510340572,0],
'[1510340573,0],[1510340574,0],[1510340575,0],[1510340576,0],[1510340577,0],[1510340578,0],[1510340579,0],
'[1510340580,0],[1510340581,0],[1510340582,0],[1510340583,0],[1510340584,0],[1510340585,0],[1510340586,0],
'[1510340587,0],[1510340588,0],[1510340589,0],[1510340590,0],[1510340591,0],[1510340592,0],[1510340593,0],
'[1510340594,0],[1510340595,0],[1510340596,0],[1510340597,0],[1510340598,0],[1510340599,0],[1510340600,0],
'[1510340601,0],[1510340602,0],[1510340603,0],[1510340604,0],[1510340605,0],[1510340606,0],[1510340607,0],
'[1510340608,0],[1510340609,0],[1510340610,0],[1510340611,0],[1510340612,0],[1510340613,0],[1510340614,0],
'[1510340615,0],[1510340616,0],[1510340617,0],[1510340618,0],[1510340619,0],[1510340620,0],[1510340621,0],
'[1510340622,0],[1510340623,0],[1510340624,0],[1510340625,0],[1510340626,0],[1510340627,0],[1510340628,0],
'[1510340629,0],[1510340630,0],[1510340631,0],[1510340632,0],[1510340633,0],[1510340634,0],[1510340635,0],
'[1510340636,0],[1510340637,0],[1510340638,0],[1510340639,0],[1510340640,0],[1510340641,0],[1510340642,0],
'[1510340643,0],[1510340644,0],[1510340645,0],[1510340646,0],[1510340647,0],[1510340648,0],[1510340649,0],
'[1510340650,0],[1510340651,0],[1510340652,0],[1510340653,0],[1510340654,0],[1510340655,0],[1510340656,0],
'[1510340657,0],[1510340658,0],[1510340659,0],[1510340660,0],[1510340661,0],[1510340662,0],[1510340663,0],
'[1510340664,0],[1510340665,0],[1510340666,0],[1510340667,0],[1510340668,0],[1510340669,0],[1510340670,0],
'[1510340671,0],[1510340672,0],[1510340673,0],[1510340674,0],[1510340675,0],[1510340676,0],[1510340677,0],
'[1510340678,0],[1510340679,0],[1510340680,0],[1510340681,0],[1510340682,0],[1510340683,0],[1510340684,0],
'[1510340685,0],[1510340686,0],[1510340687,0],[1510340688,0],[1510340689,0],[1510340690,0],[1510340691,0],
'[1510340692,0],[1510340693,0],[1510340694,0],[1510340695,0],[1510340696,0],[1510340697,0],[1510340698,0],
'[1510340699,0],[1510340700,0],[1510340701,0],[1510340702,0],[1510340703,0],[1510340704,0],[1510340705,0],
'[1510340706,0],[1510340707,0],[1510340708,0],[1510340709,0],[1510340710,0],[1510340711,0],[1510340712,0],
'[1510340713,0],[1510340714,0],[1510340715,0],[1510340716,0],[1510340717,0],[1510340718,0],[1510340719,0],
'[1510340720,0],[1510340721,0],[1510340722,0],[1510340723,0],[1510340724,0],[1510340725,0],[1510340726,0],
'[1510340727,0],[1510340728,0],[1510340729,0],[1510340730,0],[1510340731,0],[1510340732,0],[1510340733,0],
'[1510340734,0],[1510340735,0],[1510340736,0],[1510340737,0],[1510340738,0],[1510340739,0],[1510340740,0],
'[1510340741,0],[1510340742,0],[1510340743,0],[1510340744,0],[1510340745,0],[1510340746,0],[1510340747,0],
'[1510340748,0],[1510340749,0],[1510340750,0],[1510340751,0],[1510340752,0],[1510340753,0],[1510340754,0],
'[1510340755,0],[1510340756,0],[1510340757,0],[1510340758,0],[1510340759,0],[1510340760,0],[1510340761,0],
'[1510340762,0],[1510340763,0],[1510340764,0],[1510340765,0],[1510340766,0],[1510340767,0],[1510340768,0],
'[1510340769,0],[1510340770,0],[1510340771,0],[1510340772,0],[1510340773,0],[1510340774,0],[1510340775,0],
'[1510340776,0],[1510340777,0],[1510340778,0],[1510340779,0],[1510340780,0],[1510340781,0],[1510340782,0],
'[1510340783,0],[1510340784,0],[1510340785,0],[1510340786,0],[1510340787,0],[1510340788,0],[1510340789,0],
'[1510340790,0],[1510340791,0],[1510340792,0],[1510340793,0],[1510340794,0],[1510340795,0],[1510340796,0],
'[1510340797,0],[1510340798,0],[1510340799,0],[1510340800,0],[1510340801,0],[1510340802,0],[1510340803,0],
'[1510340804,0],[1510340805,0],[1510340806,0],[1510340807,0],[1510340808,0],[1510340809,0],[1510340810,0],
'[1510340811,0],[1510340812,0],[1510340813,0],[1510340814,0],[1510340815,0],[1510340816,0],[1510340817,0],
'[1510340818,0],[1510340819,0],[1510340820,0],[1510340821,0],[1510340822,0],[1510340823,0],[1510340824,0],
'[1510340825,0],[1510340826,0],[1510340827,0],[1510340828,0],[1510340829,0],[1510340830,0],[1510340831,0],
'[1510340832,0],[1510340833,0],[1510340834,0],[1510340835,0],[1510340836,0],[1510340837,0],[1510340838,0],
'[1510340839,0],[1510340840,0],[1510340841,0]]},"error":false,"systime":1510340845}

'{"ok":true,"type":"response","time":0.74188394899829,"rv"{"data":["Time,Min,Average,Max",
'"1507055429,679,679,679","1507055430,679,679,679","1507055431,679,679,679","1507055432,679,679,679",
'"1507055433,679,679,679","1507055434,679,679,679","1507055435,679,679,679","1507055436,679,679,679",
'"1507055437,679,679,679","1507055438,679,679,679","1507055439,637,637,637","1507055440,637,637,637",
'"1507055441,637,637,637","1507055442,637,637,637","1507055443,637,637,637","1507055444,637,637,637",
'"1507055445,637,637,637","1507055446,637,637,637","1507055447,637,637,637","1507055448,637,637,637",
'"1507055449,637,637,637","1507055450,637,637,637","1507055451,637,637,637","1507055452,637,637,637",
'"1507055453,637,637,637","1507055454,637,637,637","1507055455,637,637,637","1507055456,637,637,637",
'"1507055457,637,637,637","1507055458,637,637,637","1507055459,638,638,638","1507055460,638,638,638",
'"1507055461,638,638,638","1507055462,676,676,676","1507055463,704,704,704","1507055464,714,714,714",
'"1507055465,714,714,714","1507055466,686,686,686","1507055467,673,673,673","1507055468,673,673,673",
'"1507055469,704,704,704","1507055470,704,704,704","1507055471,671,671,671","1507055472,676,676,676",
'"1507055473,669,669,669","1507055474,685,685,685","1507055475,672,672,672","1507055476,669,669,669",
'"1507055477,670,670,670","1507055478,669,669,669","1507055479,669,669,669","1507055480,670,670,670",
'"1507055481,669,669,669","1507055482,670,670,670","1507055483,671,671,671","1507055484,670,670,670",
'"1507055485,671,671,671","1507055486,679,679,679","1507055487,679,679,679","1507055488,678,678,678",
'"1507055489,677,677,677","1507055490,677,677,677","1507055491,678,678,678","1507055492,680,680,680",
'"1507055493,677,677,677","1507055494,719,719,719","1507055495,680,680,680","1507055496,679,679,679",
'"1507055497,681,681,681","1507055498,677,677,677","1507055499,677,677,677","1507055500,678,678,678",
'"1507055501,681,681,681","1507055502,677,677,677","1507055503,677,677,677","1507055504,678,678,678",
'"1507055505,680,680,680","1507055506,680,680,680","1507055507,679,679,679","1507055508,677,677,677",
'"1507055509,675,675,675","1507055510,676,676,676","1507055511,677,677,677","1507055512,678,678,678",
'"1507055513,675,675,675","1507055514,677,677,677","1507055515,678,678,678","1507055516,677,677,677",
'"1507055517,677,677,677","1507055518,678,678,678","1507055519,677,677,677","1507055520,677,677,677",
'"1507055521,677,677,677","1507055522,677,677,677","1507055523,677,677,677","1507055524,675,675,675",
'"1507055525,678,678,678","1507055526,675,675,675","1507055527,669,669,669","1507055528,669,669,669",
'"1507055529,670,670,670","1507055530,673,673,673","1507055531,669,669,669","1507055532,671,671,671",
'"1507055533,670,670,670","1507055534,670,670,670","1507055535,670,670,670","1507055536,668,668,668",
'"1507055537,669,669,669","1507055538,669,669,669","1507055539,668,668,668","1507055540,669,669,669",
'"1507055541,668,668,668","1507055542,668,668,668","1507055543,668,668,668","1507055544,668,668,668",
'"1507055545,712,712,712","1507055546,669,669,669","1507055547,671,671,671","1507055548,671,671,671",
'"1507055549,670,670,670","1507055550,669,669,669","1507055551,667,667,667","1507055552,672,672,672",
'"1507055553,673,673,673","1507055554,673,673,673","1507055555,669,669,669","1507055556,672,672,672",
'"1507055557,668,668,668","1507055558,669,669,669","1507055559,665,665,665","1507055560,664,664,664",
'"1507055561,670,670,670","1507055562,663,663,663","1507055563,663,663,663","1507055564,663,663,663",
'"1507055565,663,663,663","1507055566,663,663,663","1507055567,665,665,665","1507055568,663,663,663",
'"1507055569,664,664,664","1507055570,663,663,663","1507055571,664,664,664","1507055572,667,667,667",
'"1507055573,664,664,664","1507055574,663,663,663","1507055575,665,665,665","1507055576,663,663,663",
'"1507055577,696,696,696","1507055578,664,664,664","1507055579,664,664,664","1507055580,665,665,665",
'"1507055581,663,663,663","1507055582,664,664,664","1507055583,665,665,665","1507055584,665,665,665",
'"1507055585,689,689,689"]},"error":false,"systime":1509733572}