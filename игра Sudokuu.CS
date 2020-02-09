использование  системы;
используя  систему .IO;
используя  систему .Данные;
используя  систему .Xml;
используя  систему .Текст;

пространство  имен судоку
{

	/// < резюме>
	/// Перечисление, определяющее уровень игры
	/// < / резюме>
	 уровень публичного  перечисления игр
	{
	   Просто,
	   Среда,
	   СЛОЖНЫЙ
	
	
	}

	/// < резюме>
	/// Перечисление игровых комбинаций для создания игры.
	/// < / резюме>
	enum  GameCombinations
	{
	   SWAP_ROWS,
	   SWAP_COLS,
	   SWAP_SETS,
	   REVERSE_ROW_OR_COL
	};
	/// < резюме>
	/// Основной класс, реализующий игру судоку.
	/// Концепция: игра генерируется с помощью первого генерирующего ответа. Ответ таков:
	/// генерируется из одного уникального решения случайным образом с использованием игровых комбинаций 
	/// указанная выше, затем разоблачение некоторых позиций на основе сложности
	//- уровень. Возможны тысячи комбинаций.
	/// < / резюме>
	публичный  класс  судоку
	{
		
		/// < резюме>
		/// Конструктор
		/// < / резюме>
		публичное  судоку()
		{
		  // Это набор ответов, сформированный из уникального решения
		  _numberSet  =  new  int [ MAX_ROWS, MAX_COLS];
		  // Это устанавливается после снятия маски с некоторых позиций и является набором проблем
		  _problemSet  = new  int [ MAX_ROWS, MAX_COLS];
		  // copy of problem set to проверяет, что позиции ответов не изменяются
			
		  _problemSetCopy  = новый  int [ MAX_ROWS, MAX_COLS];
		}


		
		/// < резюме>
		/// Свойство: Набор Игр
		/// Возврат набора игр в качестве набора данных
		/// < / резюме>
		общий  набор  данных GameSet
		{
		
			get{return FormDataSet();}


		}

	
		/// < резюме>
		/// Метод: GenerateGame
		/// Назначение: генерирует игру на основе уровня сложности.
		/// < / резюме>
		/// < param  name = "уровень" > > < / param>
		public  void  GenerateGame ( уровень GameLevel)
		{
		
			// InitialiseSet
			// Сначала создается набор ответов с помощью игровых комбинаций
			InitialiseSet();
			int  minPos, maxPos, noOfSets;
			 
			// Теперь снимите маски позиций и создать набор проблем.
			переключатель (уровень)
			{
			
				кейс  GameLevel .Просто:
					minPos=4;
					maxPos=6;
					noOfSets=8;
					UnMask (minPos, maxPos, noOfSets);
					перерыв;
				кейс  GameLevel .Среда:
					minPos=3;
					maxPos=5;
					noOfSets= 7;
					UnMask (minPos, maxPos, noOfSets);
					перерыв;
				кейс  GameLevel .Комплекс:
					 minPos=3;
					 maxPos=5;
					noOfSets = 6;
					UnMask (minPos, maxPos, noOfSets);
					 перерыв;
				по умолчанию:
					 Снять маску ( 3, 6, 7);
					  перерыв;
			}
			// Сделать копию набора задач
			for ( int  i = 0; i< MAX_ROWS; i ++)
			{
				для ( int  j = 0; j< MAX_COLS; j ++)
				{
				
					_problemSetCopy [ i, j ] = _problemSet [ i , j];
				}
			}

		
		
		}


		/// < резюме>
		/// Метод: Снять Маску
		/// Назначение: разоблачители устанавливают позиции случайным образом в зависимости от сложности.
		/// < / резюме>
		/// < param  name = "minPos" > > < / param>
		/// < param  name = "maxPos" > > < / param>
		private  void  UnMask ( int  minPos, int  maxPos , int  noOfSets)
		{
			int seed;
			int [] posX = {0,0,0,1,1,1,2,2,2};
			int [] posY = {0,1,2,0,1,2,0,1,2};
			int [] maskedSet={0,0,0,0,0,0,0,0,0};
			Случайное  число;
		    int setCount =0;
			делать
			{

				seed= DateTime.- Сейчас же .Миллисекунда;
				число  =  новый  случайный (seed);
				int  i =  число .Далее ( 0, 9);
				
				if ( maskedSet [ i ] = = 0)
				{
					maskedSet[i]=1;
					setCount++;
					// Маска каждого набора
			
						seed = DateTime.- Сейчас же .Миллисекунда;
					число  =  новый  случайный (seed);
					int  maskPos  =  число .Далее (minPos, maxPos);
					int j=0;
					делать
					{
						seed  = DateTime.- Сейчас же .Миллисекунда;
						число  =  новый  случайный (seed);
						int  newPos  =  число .Далее ( 1, 9);
						int x = _setRowPosition[i]+posX[newPos];
						int y=  _setColPosition[i]+posY[newPos];
						если ( _problemSet [ x, y ] = = 0)
						{
							_problemSet [ x, y ] = _numberSet [ x , y];
							j++;
						}
				
 }while(j<maskPos);
			
			
				}
 }while(setCount < noOfSets);

			  
			
// for(int i=0; i)
//			{
// for(int j=0; j)
//				{
// Консоль.Напишите ("{0},", _problemSet[i, j]);
//
//				
//				}
// Консоль.метод WriteLine("");
//			}
//		
// Консоль.WriteLine ("пожалуйста, проверьте");

		}



		public  bool  Initialiseexistinggame ( набор  данных gameSet)
		{
		     // Initialiase Answerset 
			пробовать
			{
				DataTable  currentTable  =  набор игр .Таблицы ["answerset "];
				int  i = 0, j = 0;
				строка  colname = null;
				foreach ( строка DataRow  в  currentTable .Строки)
				{
					для ( j = 0; j< MAX_COLS; j ++)
					{

						colname = "col" +j.ToString().TrimEnd();
					    string  dataValue  =  строка [ colname ] в  виде строки;
						if (dataValue  = =  null)
							продолжить;

						if(dataValue.TrimEnd()!="")
						{
							_numberSet [ i, j ] =  Int32 .Parse(dataValue);
						}
						еще
						{
							_numberSet[i,j]=0;
						}
						
					}
						i++;
				}

				// Initilise problemset
				i=j=0;
				currentTable = gameSet.Tables["numberset"];
				foreach ( строка DataRow  в  currentTable .Строки)
				{
					для ( j = 0; j< MAX_COLS; j ++)
					{
						colname = "col" +j.ToString().TrimEnd();
					
						string  dataValue  =  строка [ colname ] в  виде строки;
						if (dataValue  = =  null)
							продолжить;

						if(dataValue.TrimEnd()!="")
						{
							_problemSet [ i, j ] =  Int32 .Parse(dataValue);
						}
						еще
						{
							_problemSet [ i, j ] = 0;
						}
						
						
					}
					i++;
				}

				// Initliase ProblemSet Copy
				i=j=0;
				currentTable  =  набор игр .Таблицы ["problemcopyset "];
				foreach ( строка DataRow  в  currentTable .Строки)
				{
					для ( j = 0; j< MAX_COLS; j ++)
					{
						colname = "col" +j.ToString().TrimEnd();
					
						string  dataValue  =  строка [ colname ] в  виде строки;
						if (dataValue  = =  null)
							продолжить;

						if(dataValue.TrimEnd()!="")
						{
							_problemSetCopy [ i, j ] =  Int32 .Parse(dataValue);
						}
						еще
						{
							_problemSetCopy [ i, j ] = 0;
						}
					
						
					}
					i++;
				}

				вернуть  true;
			
			}
			catch (исключение  ex)
			{
			  Консоль .WriteLine ("ошибка произошла во время инициализации игры и ошибка составляет {0}" , ex .Сообщение);
				вернуть  false;
			}
			
		
		}
		/// < резюме>
		/// Метод: CheckForDuplicate
		/// < / резюме>
		/// < param  name = "rowPos" > > < / param>
		/// < param  name = "colPos" > > < / param>
		/// < param  name = "currentValue" > > < / param>
		/// < returns>>< / returns>

		public  bool  CheckForDuplicate ( int  rowPos, int  colPos, int  currentValue)
		{
		  // проверить строки
			for ( int  i = 0; i< MAX_ROWS; i ++)
			{
				
				if (_problemSet [ i, colPos ] ==  currentValue)
				{
					если (я !=rowPos)
					{
						вернуть  true;
 } остальное{
						продолжить;}
						
				}
				if (_problemSet [ rowPos, i ] ==  currentValue)
				{
					если (я != colPos){
						вернуть  true;} else{
						продолжить;}
				}

			}

			// Check in Mini Set
				int x = rowPos /3;
				int y = colPos/3;
				для ( int  j = 0; j< MINI_SET_ROWS ; j ++)
				{
					для ( int  k = 0; k< MINI_SET_COLS ; k ++)
					{
						int p = x*3+j;
						int q = y*3+k;

						если ((p = = rowPos ) & & (q == colPos))
						{
							продолжить;
 } иначе  если ( _problemSet [ p, q ] ==  currentValue)
						{
						    вернуть  true;
						}
					
					}

				}
			
				вернуть  false;
			
		
		
		}

		public  bool  CheckIfAnswerPosition ( int  rowPos, int  colPos , int  dataValue)
		{
		
			
				если ( _problemSetCopy [ rowPos, colPos]!=0)
					вернуть  true;
			    еще
					 вернуть  false;
			
		
		
		
		}


		/// < резюме>
		/// Метод: CheckForAnswerChange
		/// < / резюме>
		/// < param  name = "rowPos" > > < / param>
		/// < param  name = "colPos" > > < / param>
		/// < param  name = "currentValue" > > < / param>
		/// < returns>>< / returns>
		public  bool  CheckForAnswerChange ( int  rowPos, int  colPos, int  currentValue)
		{
			если ( _problemSetCopy [ rowPos, colPos]!=0)
			{
				если ( _problemSetCopy [ rowPos, colPos]!= currentValue)
				{
				   вернуть  true;
				}
			}
			вернуть  false;
		
		}

		/// < резюме>
		/// Метод: FormDataSet
		/// Назначение: создает XML динамически из массива задач, копии набора ответов набора задач
		/// Возвращает как DataSet. Легко привязать к сетке.
		/// < / резюме>
		/// < param  name = "currentSet" > > < / param>
		/// < returns>>< / returns>
		частный  набор  данных FormDataSet()
		{
		
			пробовать
			{
				DataSet  ds  =  новый  набор данных ("sudokuset ");

				StringBuilder  sb  =  новый  StringBuilder();
				sb.Добавление ( "xml version= \ "1.0 \" encoding= \ " utf-8 \"?>");
				sb.Добавление ("<судокусет><судокусет> ");
				sb.Добавить ("<numbersets><numbersets> ");

				for ( int  i = 0; i< MAX_ROWS; i ++)
				{
					sb.Добавление ("<numberset><numberset> ");
					для ( int  j = 0; j< MAX_COLS; j ++)
					{
					
						sb.Добавление ("<col " + j .ToString().TrimEnd () +">> ");
						если ( _problemSet [ i, j ] = = 0)
							sb.Добавление ( "  ");
						еще
							sb.Добавить ( _problemSet [ i, j ].ToString().TrimEnd());
						sb.Добавление ("</col " + j .ToString().TrimEnd () +">> ");
						sb.Добавление ("\n ");
				
					}
					sb.Добавление ("</numberset>< / numberset> ");
					sb.Добавление ("\n ");
				}
				sb.Добавить ("</numbersets>< / numbersets> ");

				// Copy ProblemCopySet
				sb.Добавить ("<problemcopysets><problemcopysets> ");

				for ( int  i = 0; i< MAX_ROWS; i ++)
				{
					sb.Добавить ("<problemcopyset><problemcopyset> ");
					для ( int  j = 0; j< MAX_COLS; j ++)
					{
					
						sb.Добавление ("<col " + j .ToString().TrimEnd () +">> ");
						if (_problemSetCopy [ i, j ] = = 0)
							sb.Добавление ( "  ");
						еще
							sb.Добавить ( _problemSetCopy [ i, j ].ToString().TrimEnd());
						sb.Добавление ("</col " + j .ToString().TrimEnd () +">> ");
						sb.Добавление ("\n ");
				
					}
					sb.Добавить ("</problemcopyset>< / problemcopyset> ");
					sb.Добавление ("\n ");
				}
				sb.Добавить ("</problemcopysets>< / problemcopysets> ");

				// Copy ProblemCopySet
				sb.Добавление ("<answersets><answersets> ");

				for ( int  i = 0; i< MAX_ROWS; i ++)
				{
					sb.Добавление ("<answerset><answerset> ");
					для ( int  j = 0; j< MAX_COLS; j ++)
					{
					
						sb.Добавление ("<col " + j .ToString().TrimEnd () +">> ");
						если ( _numberSet [ i, j ] = = 0)
							sb.Добавление ( "  ");
						еще
							sb.Добавление (_numberSet [ i, j].ToString().TrimEnd());
						sb.Добавление ("</col " + j .ToString().TrimEnd () +">> ");
						sb.Добавление ("\n ");
				
					}
					sb.Добавление ("</answerset > < / answerset> ");
					sb.Добавление ("\n ");
				}
				sb.Добавление ("</answersets > < / answersets> ");

				sb.Добавление ("</sudokuset > < / sudokuset> ");
				// Консоль.WriteLine(sb.ToString());

			
				StringReader  sr  =  новый  StringReader ( sb .ToString());
			  
				ДС .ReadXml(sr);
			  
			  
				возврат  ds;
			}
			catch (исключение  ex)
			{
				Консоль .WriteLine ("ошибка ocurred при формировании набора данных и является {0}", ex .Сообщение);
				вернуть  null;
			}
		
		}


	
		
		
		
		/// <summary>
		/// Method:InitialiseSet
		/// Purpose:Creates Answer Set
		/// </summary>
		private void InitialiseSet()
		{
			int seed = DateTime.Now.Millisecond %3;
			

			for(int i=0;i<MAX_ROWS;i++)
			{
				for(int j=0;j<MAX_COLS;j++)
				{
				
				  _numberSet[i,j] =_originalSet[i,j];
				  _problemSet[i,j]=0;
				  _problemSetCopy[i,j]=0;
				}
			}
			 Random number = new Random(seed);
			 int roworcolPos = number.Next(1,3);
			  seed = DateTime.Now.Millisecond %3;
			  number = new Random(seed);
			 int setNumber = number.Next(1,3);
			if(_swapRows)
			{
				// swapRows
				  SwapData(setNumber,roworcolPos,GameCombinations.SWAP_ROWS);
				_swapRows =false;  
			}
			else
			{
			   // swapCols
				  SwapData(setNumber,roworcolPos,GameCombinations.SWAP_COLS);
				_swapRows=true;
			}
			 
               seed = DateTime.Now.Millisecond %3;
			    number = new Random(seed);
			   setNumber = number.Next(1,3);
			   // swapSet
			     SwapData(setNumber,roworcolPos,GameCombinations.SWAP_SETS);

		
             
		}

		/// <summary>
		/// Method:SwapData
		/// </summary>
		/// <param name="setNumber"></param>
		/// <param name="roworcolPos"></param>
		/// <param name="swapType"></param>

		private void SwapData(int setNumber,int roworcolPos,GameCombinations swapType)
		{
			
			int x1=0,x2=0,y1=0,y2=0;
			int i=0,j=0;
			switch(swapType)
			{
				case GameCombinations.SWAP_COLS:
					  y1= _setColPosition[setNumber*3]+roworcolPos;
					if(roworcolPos==2)
					{
						y2 =_setColPosition[setNumber*3];
					}
					else
					{
						y2 = y1+1;
					}
					for(i=0;i<MAX_ROWS;i++)
					{
						
					    _numberSet[i,y2] = _originalSet[i,y1];
						_numberSet[i,y1] = _originalSet[i,y2];
					
					}
					break;
				case GameCombinations.SWAP_ROWS:
					x1= _setRowPosition[setNumber*3]+roworcolPos;
					if(roworcolPos==2)
					{
						x2 =_setRowPosition[setNumber*3];
					}
					else
					{
						x2 =x1+1;
					}
					for(i=0;i<MAX_COLS;i++)
					{
						
						_numberSet[x2,i] = _originalSet[x1,i];
						_numberSet[x1,i] = _originalSet[x2,i];
					
					}
					break;

				case GameCombinations.SWAP_SETS:
					if(_swapRows)
					{
						x1 = setNumber;
						if(setNumber == 2)
							x2 =0;
						else
							x2 = x1+1;

						for(j=0;j<MAX_COLS;j++)
						{
							for(i=0;i<MINI_SET_ROWS;i++)
							{
								int temp =_numberSet[x2*3+i,j];
								_numberSet[x2*3+i,j] =_numberSet[x1*3+i,j];
								_numberSet[x1*3+i,j] =temp;
								
							}
						}
					  
					}
					else
					{
						y1 = setNumber;
						if(setNumber == 2)
							y2 =0;
						else
							y2 = y1+1;

						for(j=0;j<MAX_ROWS;j++)
						{
							for(i=0;i<MINI_SET_COLS;i++)
							{
								int temp = _numberSet[j,y1*3+i];
								_numberSet[j,y1*3+i] =_numberSet[j,y2*3+i];
								_numberSet[j,y2*3+i] = temp;
							}
						}
					
					
					
					}
					  break;
				default:
					break;
							
				
				
			
			
			}
		
		
		
		}

      /// <summary>
      /// Method:SwapNumberSet
      /// </summary>
      /// <param name="x1"></param>
      /// <param name="y1"></param>
      /// <param name="x2"></param>
      /// <param name="y2"></param>
      /// <param name="roworcol"></param>
      /// <returns></returns>

		private bool SwapNumberSet(int x1,int y1, int x2,int y2,int roworcol)
		{
			int n1,n2,n3,n4,cnt=0;
			if(roworcol==1)
			{
				n1 = _numberSet[x1,y1];
				n2 = _numberSet[x2,y1];
				n3 = _numberSet[x2,y2];
				n4 = _numberSet[x1,y2];
				_numberSet[x1,y1]=n2;
				_numberSet[x2,y1]=n1;
				_numberSet[x2,y2] =n4;
				_numberSet[x1,y2] =n3;

			}
			else
			{
				n1 =_numberSet[x1,y1];
				n2 =_numberSet[x1,y2];
				n3 =_numberSet[x2,y1];
				n4 =_numberSet[x2,y2];
				_numberSet[x1,y1]=n2;
				_numberSet[x1,y2]=n1;
				_numberSet[x2,y1] =n4;
				_numberSet[x2,y2]=n3;
			}
		  
			if(roworcol ==1)
			{
				for(int i=1; i<=MAX_ROWS;i++)
				{
					cnt =0;
					for(int j=0;j<MAX_COLS;j++)
					{
				
						if(_numberSet[x1,j]==i)
							cnt++;
					}
					if(cnt > 1)
					{
						_numberSet[x1,y1]=n1;
						_numberSet[x2,y1]=n2;
						_numberSet[x2,y2]=n3;
						_numberSet[x1,y2]=n4;
          
						return false;
					}
				}

				for(int i=1; i<=MAX_ROWS;i++)
				{
					cnt =0;
					for(int j=0;j<MAX_COLS;j++)
					{
				
						if(_numberSet[x2,j]==i)
							cnt++;
					}
					if(cnt > 1)
					{
						_numberSet[x1,y1]=n1;
						_numberSet[x2,y1]=n2;
						_numberSet[x2,y2]=n3;
						_numberSet[x1,y2]=n4;
          
						return false;
					}
				}

			}
			else
			{
				for(int i=1; i<=MAX_ROWS;i++)
				{
					cnt =0;
					for(int j=0;j<MAX_ROWS;j++)
					{
				
						if(_numberSet[j,y1]==i)
							cnt++;
					}
					if(cnt > 1)
					{
						_numberSet[x1,y1]=n1;
						_numberSet[x1,y2]=n2;
						_numberSet[x2,y1]=n3;
						_numberSet[x2,y2]=n4;
          
						return false;
				
					}	
				}

				for(int i=1; i<=MAX_ROWS;i++)
				{
					cnt =0;
					for(int j=0;j<MAX_ROWS;j++)
					{
				
						if(_numberSet[j,y2]==i)
							cnt++;
					}
					if(cnt > 1)
					{
						_numberSet[x1,y1]=n1;
						_numberSet[x1,y2]=n2;
						_numberSet[x2,y1]=n3;
						_numberSet[x2,y2]=n4;
          
						return false;
					}
					
				}
			
			
			}

		  
			return true;
		}

		/// <summary>
		/// Method: SwapNumber
		/// </summary>
		/// <param name="pos"></param>
		/// <param name="number"></param>
		/// <param name="set1"></param>
		/// <param name="setNumber"></param>
		/// <returns></returns>


		private bool SwapNumber(int pos,int number,int set1,int setNumber)
		{
			int [] xpos = {0,0,0,1,1,1,2,2,2};
			int [] ypos = {0,1,2,0,1,2,0,1,2};
			int x=0,y=0,x1,y1;
			bool duplicate=false;
			for(int i=0;i<MAX_ROWS;i++)
			{
				duplicate=false;

				if(i !=pos)
				{
					x = _setRowPosition[setNumber]+ xpos[i];
					y = _setColPosition[setNumber]+ ypos[i];
				
					duplicate=false;
					for(int j=0;j<MAX_COLS;j++)
					{
						if((_numberSet[x,j] ==number)||(_numberSet[j,y]==number))
						{
							duplicate =true;
							j=MAX_COLS;
						}
					}
					if(!duplicate)
					{
				
						int newNumber = _numberSet[x,y];
						x1 = _setRowPosition[setNumber]+ xpos[pos];
						y1 = _setColPosition[setNumber]+ ypos[pos];
						_numberSet[x,y]=0;
						for(int j=0;j<MAX_COLS;j++)
						{
							if((_numberSet[x1,j] ==newNumber)||(_numberSet[j,y1]==newNumber))
							{
								duplicate =true;
								_numberSet[x,y]=newNumber;
								j=MAX_COLS;
							}
						}

						if(!duplicate)
						{
							// swap Numbers
							_numberSet[x,y] =number;
							_numberSet[x1,y1]=newNumber;
							return true;
					
					
						}
				
				
				
					}

				}
				
			}
		
			вернуть  false;
		
		}

 #  поля региона
		bool _swapRows =true;
		private int[,] _originalSet = {{7,9,2,3,5,1,8,4,6},
									 {4,6,8,9,2,7,5,1,3},
									 {1,3,5,6,8,4,7,9,2},
									 {6,2,1,5,7,9,4,3,8},
									 {5,8,3,2,4,6,1,7,9},
									 {9,7,4,8,1,3,2,6,5},
									 {8,1,6,4,9,2,3,5,7},
									 {3,5,7,1,6,8,9,2,4},
									 {2,4,9,7,3,5,6,8,1}
									};
		private int [,] _numberSet;
		private int [,] _problemSet;
		private int [,] _problemSetCopy;
		private int[] _setRowPosition = {0,0,0,3,3,3,6,6,6};
		private int[] _setColPosition = {0,3,6,0,3,6,0,3,6};
	
 #endregion fields

 #  константы региона
		private const int MAX_ROWS =9;
		private const int MAX_COLS=9;
		private const int MINI_SET_ROWS =3;
		private const int MINI_SET_COLS =3;
 # константы эндрегиона

	}
}
