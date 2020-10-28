# AI-Based Malicious Code Detection API

> last update: 29/10/2020 by Zedi.

> **this API is part of my individual project, which can accept code to be evaluated by RESTful request. **
>
> **This server will run a pre-trained machine learning model to evaluate code, then return the result of weather the code is malicious with accuracy score**

#### **Request example:**

- `POST`: http://120.78.171.56/api/Predict 

  ```json
  {
      "Code":"while(true);"
  }
  ```

#### response exapmple:

- `JSON`:

  ```
  {
      "prediction": "1",
      "score": [
          0.026804714,
          0.9731953
      ]
  }
  ```

### Training Details:

```
|     Trainer                              MicroAccuracy  MacroAccuracy  Duration #Iteration                     |
|1    AveragedPerceptronOva                       0.7143         0.6500       1.7          1                     |
|2    SdcaMaximumEntropyMulti                     0.7143         0.6500       1.7          2                     |
|3    LightGbmMulti                               0.5714         0.5500       1.3          3                     |
|4    SymbolicSgdLogisticRegressionOva            0.6667         0.8000       1.0          4                     |
|5    FastTreeOva                                 0.5000         0.3333       1.4          5                     |
|6    LinearSvmOva                                0.7143         0.6500       0.8          6                     |
|7    LbfgsLogisticRegressionOva                  0.5714         0.7000       1.1          7                     |

-------------------------------------------------------------------------------------
|     Trainer                              MicroAccuracy  MacroAccuracy  Duration #Iteration                 |
|1    AveragedPerceptronOva                       0.7143         0.6500       1.7          1                     |
|2    SdcaMaximumEntropyMulti                     0.7143         0.6500       1.7          2                     |
|3    LinearSvmOva                                0.7143         0.6500       0.8          3                     |
|4    SymbolicSgdLogisticRegressionOva            0.6667         0.8000       1.0          4                     |
|5    LightGbmMulti                               0.5714         0.5500       1.3          5                     |
-------------------------------------------------------------------------------------
```

### DataSet snapshoot:

I created this dataset for machine learning manully, based on my experience, codes relates to 

- Label: `Malicious`
- Feature: `Code`

`0` means potentially malicious or cause infinite loop, `1` means not malicous.

```
Malicious	Code	Dump
0	int a; 	FALSE
0	int b;   	TRUE
0	int c;	FALSE
0	int d;	FALSE
0	  int e;	FALSE
0	  int f   	TRUE
0	  int A;	TRUE
0	  int Z;	FALSE
0	int azasd   	FALSE
0	int x = 0;	FALSE
1	  while(true);	TRUE
1	  for(;;);   	TRUE
0	  for(i=0;i<10;i++);	FALSE
0	 return;   	TRUE
1	  while(a<10);	TRUE
0	  for(i=0;i>10;i--);   	TRUE
1	   using  	TRUE
0	  while(a>10)	FALSE
1	  StreamReader  	TRUE
1	  Type type = i.GetType();	TRUE
1	 Assembly info = typeof(int).Assembly;   	TRUE
1	Windows.Networking	TRUE
1	  System.IO     	TRUE
1	  System.Net   	FALSE
0	int x = 12345; // int is a 32-bit integer	FALSE
0	 long y = x; // Implicit conversion to 64-bit integral type   	TRUE
0	   short z = (short)x;	FALSE
0	   int i = 1;	FALSE
0	float f = i;	TRUE
1	  int a = int.MinValue;   	FALSE
1	string s1 = null;	TRUE
1	  using Outer.Middle.Inner;	TRUE
0	  object obj =x; //box the int.  	TRUE
1	for(i=0;i<10;i--);	TRUE
1	 SELECT * FROM products WHERE id = 10; DROP members--  	TRUE
1	 IF (1=1) SELECT 'true' ELSE SELECT 'false'     	TRUE
1	  SELECT * FROM Users WHERE UserId = 105 OR 1=1;  	TRUE
1	  SELECT * FROM Users; DROP TABLE Suppliers	TRUE
1	   SELECT * FROM Users WHERE UserId = 105; DROP TABLE Suppliers;	FALSE
1	  DROP sampletable;--   	TRUE
1	  DROP sampletable;#	TRUE
1	 AND I EVEN PUT A LINK TO A HIGHLIGHTS VIDEO ON YOUTUBE	TRUE
1	  SELECT * FROM members WHERE username = 'admin'--' AND password =	FALSE
0	  string a;	FALSE
0	  string b;	FALSE
0	string xyz1 	FALSE
0	//asdadsasd   	TRUE
0	//jkbasdibiqwd int asd	FALSE
0	//12basd8asdbkasd	FALSE
0	  // asdjjqiwqdw	FALSE
0	  File   	TRUE
```

