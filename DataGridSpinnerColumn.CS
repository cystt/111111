ткрытый  класс  DataGridSpinnerColumn : DataGridTextBoxColumn

	{

		частный   вход _currentRow = - 1;
		private CurrencyManager cm=null;
		Приватный 	VScrollBar  vsBar;
		частное  судоку  _game;
		private bool _answerPostion=false; 
		private const int COLUMN_WIDTH=30;


		
		/// < резюме>
		/// Конструктор
		/// < / резюме>
		публичная  колонка DataGridSpinnerColumn()
		{

			vsBar  =  новый  VScrollBar();
			// Добавить обработчик событий Scroll и Leave
			всбар .Scroll  +=  новый  ScrollEventHandler ( Vertical_Scroll);
			всбар .Оставьте  +=  новый  EventHandler ( Vertical_Scroll_Leave);
			- вот это .Текстовое поле .Оставить  +=  новый  EventHandler ( TextBox_Leave);

			}



		public int SpinnerWidth 
		{
			get {return vsBar.Width;}
			set { vsBar.Width=value;}


		}

		public int ScrollMaximum
		{
			set{ vsBar.Maximum = value;}
			get{ return vsBar.Maximum;}
		}

		public int ScrollMinimum 
		{
			get { return vsBar.Minimum;}
			set { vsBar.Minimum=value;}

		}

		public int ScrollSmallChange
		{
			get{return vsBar.SmallChange;}
			set{ vsBar.SmallChange =value;
				vsBar.LargeChange=value;}
		}


		public Sudoku Game
		{
			set {_game=value;}

		}

		private void Vertical_Scroll(object sender, ScrollEventArgs e)
		{
			try
			{
			int dataValue = e.NewValue;
				this.TextBox.Text =dataValue.ToString();
				
			}catch(Exception ex)
				 {
					Console.WriteLine("Error occured while scroll and is {0}",ex.Message);

				 }
		}

	ivate void TextBox_Leave(object sender,EventArgs e)
		{

			// Set the value back
			
			
				if (this.TextBox.Text.ToString().TrimEnd()!="")
				{
					string s = this.TextBox.Text;
					base.SetColumnValueAtRow(this.cm,this._currentRow,s);
					
							
					
				}
				else
				{
					this.TextBox.ReadOnly=false;
				}
			
			if(!_answerPostion)
			{
				this.vsBar.Hide();
				this.DataGridTableStyle.DataGrid.Scroll -= 
					new EventHandler(DataGrid_Scroll);     
				Invalidate();

			}
			

			
			
		
		}
		
	
		private void Vertical_Scroll_Leave(object sender,EventArgs e)
		{

			// Set the value back
			
			
				if (this.TextBox.Text.ToString().TrimEnd()!="")
				{
					string s = this.TextBox.Text;
					base.SetColumnValueAtRow(this.cm,this._currentRow,s);
				}
				
			if(!_answerPostion)
			{
				this.vsBar.Hide();
				this.DataGridTableStyle.DataGrid.Scroll -= 
					new EventHandler(DataGrid_Scroll);   
				Invalidate();
			
			}
			
		  
				
			

		/// 
>
		/// <param name="sender"></param>
		/// <param name="e"></param>
//		private void Vertical_Scroll_KeyUp(object sender,KeyEventArgs e)
//		{
//			if(e.KeyCode == Keys.Up)
//			{
//				if(vsBar.Value > vsBar.Minimum)
//				{
//					vsBar.Value--;
//					this.TextBox.Text = vsBar.Value.ToString();
//				}
//			
//			}
//		
//			if(e.KeyCode == Keys.Down)
//			{
//				if(vsBar.Value < vsBar.Maximum)
//				{
//					vsBar.Value++;
//					this.TextBox.Text = vsBar.Value.ToString();
//				
//				}
//			}
//		}
//		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="rowNum"></param>
		/// <param name="bounds"></param>
		/// <param name="readOnly"></param>
		/// <param name="instantText"></param>
		/// <param name="cellIsVisible"></param>
		
		// On edit, add scroll event handler, and display combobox
		protected override void Edit(System.Windows.Forms.CurrencyManager 
			source, int rowNum, System.Drawing.Rectangle bounds, bool readOnly, 
			string instantText, bool cellIsVisible)
		{
			base.Edit(source, rowNum, bounds, readOnly, instantText, 
				cellIsVisible);

			if(this.TextBox.Text.TrimEnd()!="")
			{

				int dataValue = Int32.Parse(this.TextBox.Text);
				int pos = this.MappingName.LastIndexOf("col");
				if(pos > -1)
				{
				    string colIndex = this.MappingName.Substring(pos+3);
					int colPos = Int32.Parse(colIndex);
					_answerPostion=_game.CheckIfAnswerPosition(rowNum,colPos,dataValue);
				}
			}
			else
			{
				 _answerPostion =false;
			}
			if (!readOnly && cellIsVisible)
			{
				
				// Save current row in the DataGrid and currency manager 
				// associated with the data source for the DataGrid
				this._currentRow = rowNum;
				this.cm = source;

				if(!_answerPostion)
				{
				
					// Add event handler for DataGrid scroll notification
					this.DataGridTableStyle.DataGrid.Scroll 
						+= new EventHandler(DataGrid_Scroll);
			
					// Site the combobox control within the current cell
					this.vsBar.Parent = this.TextBox.Parent;
					Rectangle rect = 
						this.DataGridTableStyle.DataGrid.GetCurrentCellBounds();
					//Place this control to right.
					this.vsBar.Location = new Point(rect.Right-this.SpinnerWidth,rect.Top);
					this.vsBar.Size = new Size(this.SpinnerWidth,this.TextBox.Height);
				

					// Make the combobox visible and place on top textbox control
					this.vsBar.Show();
					// As textbox control also there let us bring this to front.
					this.vsBar.BringToFront();
					
					this.vsBar.Show();
					//	this.TextBox.Text= this.vsBar.Value.ToString();
					this.TextBox.ReadOnly=true;
					this.TextBox.BackColor = Color.Blue;
					this.TextBox.ForeColor=Color.White;
				
				}
				else
				{
					this.TextBox.ReadOnly=true;
					this.TextBox.BackColor=Color.White;
					this.TextBox.ForeColor =Color.Black;
				}
				
			}
		}

		public void DataGrid_Scroll(object sender,EventArgs e)
		{
		  - вот это .всбар .Скрыть();
		}

		
		// Учитывая строку, получите элемент value, связанный со строкой. Используйте
		// value элемент, чтобы найти связанный элемент отображения путем итерации 
		// над связанным источником данных
		защищенный   объект переопределения 
			GetColumnValueAtRow(System.Окна .Формы . Источник CurrencyManager, 
			int rowNum)
		{
			// Учитывая номер строки в DataGrid, получите элемент отображения
			
			объект  obj  =   база .GetColumnValueAtRow ( источник, rowNum);
			if(obj.ToString().TrimEnd() !="")
			{
				- вот это .всбар .Value = Int32.Parse(obj.ToString());
				/- вот это.текстовый.Text= obj.ToString();
			}
			еще
			{
				- вот это .всбар .Значение  = 1;
				
		
			}

			возврат  объекта;
        
		}



		
	}
}
