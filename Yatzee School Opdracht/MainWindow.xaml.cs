using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Yatzee_School_Opdracht
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public Image Button_1_Image = new Image();
		public Image Button_2_Image = new Image();
		public Image Button_3_Image = new Image();
		public Image Button_4_Image = new Image();
		public Image Button_5_Image = new Image();

		public string ForEndResult = "0";

		public int rollvolume = 100;

		public bool Vastgezet1 = false;
		public bool Vastgezet2 = false;
		public bool Vastgezet3 = false;
		public bool Vastgezet4 = false;
		public bool Vastgezet5 = false;

		//Hieronder de Scores per sectie
		public int Count_And_Add_Only_Aces_Score = 0;
		public int Count_And_Add_Only_Twos_Score = 0;
		public int Count_And_Add_Only_Threes_Score = 0;
		public int Count_And_Add_Only_Fours_Score = 0;
		public int Count_And_Add_Only_Fives_Score = 0;
		public int Count_And_Add_Only_Sixes_Score = 0;
		public int Three_Of_A_Kind_TotalAllDices_Score = 0;
		public int Four_Of_A_Kind_TotalAllDices_Score = 0;
		public int Full_House_25_Score = 0;
		public int Low_Straight_30_Score = 0;
		public int High_Straight_40_Score = 0;
		public int Yahtzee_Score = 0;
		public int Chance_Total_Of_All_Dices_Score = 0;
		public int Yahtzee_Bonus_Score = 0;
		//Hierboven de Scores per sectie

		//Hieronder zet ik alle Booleans neer van condities of iets wel of niet mogelijk is;
		//Kan ik wel of niet een knop klikken?

		public bool Count_And_Add_Only_Aces_CanClick = false;
		public bool Count_And_Add_Only_Twos_CanClick = false;
		public bool Count_And_Add_Only_Threes_CanClick = false;
		public bool Count_And_Add_Only_Fours_CanClick = false;
		public bool Count_And_Add_Only_Fives_CanClick = false;
		public bool Count_And_Add_Only_Sixes_CanClick = false;
		public bool Three_Of_A_Kind_TotalAllDices_CanClick = false;
		public bool Four_Of_A_Kind_TotalAllDices_CanClick = false;
		public bool Full_House_25_CanClick = false;
		public bool Low_Straight_30_CanClick = false;
		public bool High_Straight_40_CanClick = false;
		public bool Yahtzee_CanClick = false;
		public bool Chance_Total_Of_All_Dices_CanClick = false;
		public bool Yahtzee_Bonus_CanClick = false;
		//-------------------------****----------------------//
		//-----------//
		public string Stone_A; public string Stone_B; public string Stone_C; public string Stone_D; public string Stone_E;

		public Grid SecondHalfButtonGrid = new Grid();

		public bool canroll; public int rollcount = 0; public int reverserollcount = 3;

		public int T_A; public int T_B; public int T_C; public int T_D; public int T_E;
		
		public bool WeHaveDoneThisAlready1 = false;
		public bool WeHaveDoneThisAlready2 = false;
		public bool WeHaveDoneThisAlready3 = false;
		public bool WeHaveDoneThisAlready4 = false;
		public bool WeHaveDoneThisAlready5 = false;
		public bool WeHaveDoneThisAlready6 = false;
		public bool WeHaveDoneThisAlready7 = false;
		public bool WeHaveDoneThisAlready8 = false;
		public bool WeHaveDoneThisAlready9 = false;
		public bool WeHaveDoneThisAlready10 = false;
		public bool WeHaveDoneThisAlready11 = false;
		public bool WeHaveDoneThisAlready12 = false;
		public bool WeHaveDoneThisAlready13 = false;
		public bool WeHaveDoneThisAlready14 = false;

		public MainWindow()
			
		{
			
			//Setup();

		}

		public void Setup()
		{

			
			int TotalValue = Count_And_Add_Only_Aces_Score + Count_And_Add_Only_Twos_Score + Count_And_Add_Only_Threes_Score + Count_And_Add_Only_Fours_Score + Count_And_Add_Only_Fives_Score + Count_And_Add_Only_Sixes_Score + Three_Of_A_Kind_TotalAllDices_Score + Four_Of_A_Kind_TotalAllDices_Score + Full_House_25_Score + Low_Straight_30_Score + High_Straight_40_Score + Yahtzee_Score + Chance_Total_Of_All_Dices_Score + Yahtzee_Bonus_Score;
			UpperTotalLabel.Content = TotalValue; int Bonus = 0; 

			if (TotalValue >= 63) { Bonus += 35; }
			else { BonusLabel.Content = "0"; }
			BonusLabel.Content = Bonus;
			T_A = 0; T_B = 0; T_C = 0; T_D = 0; T_E = 0;
			PlaySound();
			Title = "Yahtzee School Opdracht";

			UpperSectionTotalLabel.Content = Convert.ToString(TotalValue + Bonus);

			SecondHalfButtonGrid = FindName("SeperationGrid") as Grid;
			Debug.WriteLine("The Seperation grid is type " + Convert.ToString(SecondHalfButtonGrid) + "And has name" + SecondHalfButtonGrid);
			Button1.Visibility = Visibility.Hidden; Button2.Visibility = Visibility.Hidden; Button3.Visibility = Visibility.Hidden; Button4.Visibility = Visibility.Hidden; Button5.Visibility = Visibility.Hidden; Button6.Visibility = Visibility.Hidden; Button7.Visibility = Visibility.Hidden; SecondHalfButtonGrid.Visibility = Visibility.Hidden;

			DobbelCounter.Visibility = Visibility.Hidden;
			DobbelCounter.Content = "U kunt nog " + reverserollcount + " keer rollen";



			Overlay.Visibility= Visibility.Hidden;
			Lock_1.Visibility = Visibility.Hidden; Lock_2.Visibility = Visibility.Hidden; Lock_3.Visibility = Visibility.Hidden; Lock_4.Visibility = Visibility.Hidden; Lock_5.Visibility = Visibility.Hidden; Button5.Visibility = Visibility.Hidden; Button6.Visibility = Visibility.Hidden; Button7.Visibility = Visibility.Hidden; SecondHalfButtonGrid.Visibility = Visibility.Hidden; 
			ResizeMode = ResizeMode.NoResize;
			Debug.WriteLine("Setup"); Wachten.Visibility = Visibility.Hidden;

			BitmapImage Empty_Unplaced = new BitmapImage(new Uri(@"Assets/None.png", UriKind.Relative));
			//>>> onderstaande zet de plaatjes van de knoppen naar NULLSTEEN
			Button_1_Image.Source = Empty_Unplaced; Button_2_Image.Source = Empty_Unplaced; Button_3_Image.Source = Empty_Unplaced; Button_4_Image.Source = Empty_Unplaced; Button_5_Image.Source = Empty_Unplaced;
			Button Bttn_a = new Button(); Button Bttn_b = new Button(); Button Bttn_c = new Button(); Button Bttn_d = new Button(); Button Bttn_e = new Button();
			Bttn_a = FindName("a_Button") as Button; Bttn_b = FindName("b_Button") as Button; Bttn_c = FindName("c_Button") as Button; Bttn_d = FindName("d_Button") as Button; Bttn_e = FindName("e_Button") as Button;
			Bttn_a.Content = Button_1_Image; Bttn_b.Content = Button_2_Image; Bttn_c.Content = Button_3_Image; Bttn_d.Content = Button_4_Image; Bttn_e.Content = Button_5_Image;

		}
		public void ResetCanRoll()
		{

			Vastgezet1 = false; Vastgezet2 = false; Vastgezet3 = false; Vastgezet4 = false; Vastgezet5 = false;

			//BitmapImage Empty_Unplaced = new BitmapImage(new Uri(@"Assets/None.png", UriKind.Relative));
			////>>> onderstaande zet de plaatjes van de knoppen naar NULLSTEEN
			//Button_1_Image.Source = Empty_Unplaced; Button_2_Image.Source = Empty_Unplaced; Button_3_Image.Source = Empty_Unplaced; Button_4_Image.Source = Empty_Unplaced; Button_5_Image.Source = Empty_Unplaced;
			//Button Bttn_a = new Button(); Button Bttn_b = new Button(); Button Bttn_c = new Button(); Button Bttn_d = new Button(); Button Bttn_e = new Button();
			//Bttn_a = FindName("a_Button") as Button; Bttn_b = FindName("b_Button") as Button; Bttn_c = FindName("c_Button") as Button; Bttn_d = FindName("d_Button") as Button; Bttn_e = FindName("e_Button") as Button;
			//Bttn_a.Content = Button_1_Image; Bttn_b.Content = Button_2_Image; Bttn_c.Content = Button_3_Image; Bttn_d.Content = Button_4_Image; Bttn_e.Content = Button_5_Image;

			Chance_Total_Of_All_Dices_CanClick = true;
			Count_And_Add_Only_Aces_CanClick = true;
			Count_And_Add_Only_Twos_CanClick = true;
			Count_And_Add_Only_Threes_CanClick = true;
			Count_And_Add_Only_Fours_CanClick = true;
			Count_And_Add_Only_Fives_CanClick = true;
			Count_And_Add_Only_Sixes_CanClick = true;
			Three_Of_A_Kind_TotalAllDices_CanClick = true;
			Four_Of_A_Kind_TotalAllDices_CanClick = true;
			Full_House_25_CanClick = true;
			Low_Straight_30_CanClick = true;
			High_Straight_40_CanClick = true;
			Yahtzee_CanClick = true;
			Chance_Total_Of_All_Dices_CanClick = true;
			Yahtzee_Bonus_CanClick = true;
			//LabelSetter();

			CheckBox Box_A = new CheckBox(); Box_A = FindName("CheckBox_1") as CheckBox; Box_A.IsChecked = false;
			CheckBox Box_B = new CheckBox(); Box_B = FindName("CheckBox_2") as CheckBox; Box_B.IsChecked = false;
			CheckBox Box_C = new CheckBox(); Box_C = FindName("CheckBox_3") as CheckBox; Box_C.IsChecked = false;
			CheckBox Box_D = new CheckBox(); Box_D = FindName("CheckBox_4") as CheckBox; Box_D.IsChecked = false;
			CheckBox Box_E = new CheckBox(); Box_E = FindName("CheckBox_5") as CheckBox; Box_E.IsChecked = false;
			Image Lock1 = new Image(); Lock1 = FindName("Lock_1") as Image; Lock1.Visibility = Visibility.Hidden;
			Image Lock2 = new Image(); Lock2 = FindName("Lock_2") as Image; Lock2.Visibility = Visibility.Hidden;
			Image Lock3 = new Image(); Lock3 = FindName("Lock_3") as Image; Lock3.Visibility = Visibility.Hidden;
			Image Lock4 = new Image(); Lock4 = FindName("Lock_4") as Image; Lock4.Visibility = Visibility.Hidden;
			Image Lock5 = new Image(); Lock5 = FindName("Lock_5") as Image; Lock5.Visibility = Visibility.Hidden;
			Image Overlayer = new Image(); Overlayer = FindName("Overlay") as Image; Overlayer.Visibility = Visibility.Hidden;
			rollvolume = 100;
			Button1.Visibility = Visibility.Hidden; Button2.Visibility = Visibility.Hidden; Button3.Visibility = Visibility.Hidden; Button4.Visibility = Visibility.Hidden; Button5.Visibility = Visibility.Hidden; Button6.Visibility = Visibility.Hidden; Button7.Visibility = Visibility.Hidden; SecondHalfButtonGrid.Visibility = Visibility.Hidden;
			reverserollcount = 3; DobbelCounter.Visibility = Visibility.Hidden;
			Image DobbelImage = new Image(); DobbelImage = FindName("DobbelKnop") as Image;
			DobbelImage.Visibility = Visibility.Visible;
			rollcount = 0;
			Wachten.Visibility = Visibility.Hidden; EnterToets.Visibility = Visibility.Visible;
			Setup();
		}
		private void RollButton_Click(object sender, RoutedEventArgs e)
		{
			ClickRoll();
		}
		private void ClickRoll()
		{
			PlaySoundRoll();

			DobbelCounter.Content = "U kunt nog " + reverserollcount + " keer rollen.";
			if (rollcount < 4) { canroll = true; } else { canroll = false; }
			if (canroll) { rollcount++; reverserollcount--; RandomiseRoll(); }
			Image DobbelImage = new Image(); DobbelImage = FindName("DobbelKnop") as Image;
			if (rollcount > 3)
			{
				DobbelImage.Visibility = Visibility.Hidden;
				rollcount = 100; awaitinput();
			}
		}
		private void awaitinput()
		{
			canroll = false;
			rollvolume = 0; PlaySoundWrite(); Button2.Visibility = Visibility.Visible;
			Button1.Visibility = Visibility.Visible; Button2.Visibility = Visibility.Visible; Button3.Visibility = Visibility.Visible; Button4.Visibility = Visibility.Visible; Button5.Visibility = Visibility.Visible; Button6.Visibility = Visibility.Visible; Button7.Visibility = Visibility.Visible; SecondHalfButtonGrid.Visibility = Visibility.Visible; RandomiseRoll(); RandomiseRoll(); RandomiseRoll();
			Debug.WriteLine("Awaiting input"); DobbelCounter.Content = "U kunt niet meer dobbelen.";
			Wachten.Visibility = Visibility.Visible;
			EnterToets.Visibility = Visibility.Hidden; Overlay.Visibility = Visibility.Visible;
			//For some odd reason i don't know and am too lazy to figure out about it repeats a lot of timesCheckBox
			PossibilityChecker();

		}
		public void RandomiseRoll()
		{
		if (canroll)
			{
				Random Range = new Random(); RollButtonKnop.Background = Brushes.Red;
				int a = Range.Next(1, 7); int b = Range.Next(1, 7); int c = Range.Next(1, 7); int d = Range.Next(1, 7); int e = Range.Next(1, 7);

				Debug.WriteLine("Randomized values are " + a + b + c + d + e);



				BitmapImage One = new BitmapImage(new Uri(@"Assets/1.png", UriKind.Relative));
				BitmapImage Two = new BitmapImage(new Uri(@"Assets/2.png", UriKind.Relative));
				BitmapImage Three = new BitmapImage(new Uri(@"Assets/3.png", UriKind.Relative));
				BitmapImage Four = new BitmapImage(new Uri(@"Assets/4.png", UriKind.Relative));
				BitmapImage Five = new BitmapImage(new Uri(@"Assets/5.png", UriKind.Relative));
				BitmapImage Six = new BitmapImage(new Uri(@"Assets/6.png", UriKind.Relative));



				if (!Vastgezet1)
				{
					if (a == 1) { Button_1_Image.Source = One; Stone_A = "ST1"; }
					if (a == 2) { Button_1_Image.Source = Two; Stone_A = "ST2"; }
					if (a == 3) { Button_1_Image.Source = Three; Stone_A = "ST3"; }
					if (a == 4) { Button_1_Image.Source = Four; Stone_A = "ST4"; }
					if (a == 5) { Button_1_Image.Source = Five; Stone_A = "ST5"; }
					if (a == 6) { Button_1_Image.Source = Six; Stone_A = "ST6"; }
				}

				if (!Vastgezet2)
				{
					if (b == 1) { Button_2_Image.Source = One; Stone_B = "ST1"; }
					if (b == 2) { Button_2_Image.Source = Two; Stone_B = "ST2"; }
					if (b == 3) { Button_2_Image.Source = Three; Stone_B = "ST3"; }
					if (b == 4) { Button_2_Image.Source = Four; Stone_B = "ST4"; }
					if (b == 5) { Button_2_Image.Source = Five; Stone_B = "ST5"; }
					if (b == 6) { Button_2_Image.Source = Six; Stone_B = "ST6"; }
				}

				if (!Vastgezet3)
				{
					if (c == 1) { Button_3_Image.Source = One; Stone_C = "ST1"; }
					if (c == 2) { Button_3_Image.Source = Two; Stone_C = "ST2"; }
					if (c == 3) { Button_3_Image.Source = Three; Stone_C = "ST3"; }
					if (c == 4) { Button_3_Image.Source = Four; Stone_C = "ST4"; }
					if (c == 5) { Button_3_Image.Source = Five; Stone_C = "ST5"; }
					if (c == 6) { Button_3_Image.Source = Six; Stone_C = "ST6"; }
				}

				if (!Vastgezet4)
				{
					if (d == 1) { Button_4_Image.Source = One; Stone_D = "ST1"; }
					if (d == 2) { Button_4_Image.Source = Two; Stone_D = "ST2"; }
					if (d == 3) { Button_4_Image.Source = Three; Stone_D = "ST3"; }
					if (d == 4) { Button_4_Image.Source = Four; Stone_D = "ST4"; }
					if (d == 5) { Button_4_Image.Source = Five; Stone_D = "ST5"; }
					if (d == 6) { Button_4_Image.Source = Six; Stone_D = "ST6"; }
				}
				if (!Vastgezet5)
				{
					if (e == 1) { Button_5_Image.Source = One; Stone_D = "ST1"; }
					if (e == 2) { Button_5_Image.Source = Two; Stone_D = "ST2"; }
					if (e == 3) { Button_5_Image.Source = Three; Stone_D = "ST3"; }
					if (e == 4) { Button_5_Image.Source = Four; Stone_D = "ST4"; }
					if (e == 5) { Button_5_Image.Source = Five; Stone_D = "ST5"; }
					if (e == 6) { Button_5_Image.Source = Six; Stone_D = "ST6"; }

				}
				if (!Vastgezet1) { T_A = a; }
				if (!Vastgezet2) { T_B = b; }
				if (!Vastgezet3) { T_C = c; }
				if (!Vastgezet4) { T_D = d; }
				if (!Vastgezet5) { T_E = e; }
				//>>> onderstaande zet de plaatjes van de knoppen naar NULLSTEEN

				Button Bttn_a = new Button(); Button Bttn_b = new Button(); Button Bttn_c = new Button(); Button Bttn_d = new Button(); Button Bttn_e = new Button();
				Bttn_a = FindName("a_Button") as Button; Bttn_b = FindName("b_Button") as Button; Bttn_c = FindName("c_Button") as Button; Bttn_d = FindName("d_Button") as Button; Bttn_e = FindName("e_Button") as Button;
				Bttn_a.Content = Button_1_Image; Bttn_b.Content = Button_2_Image; Bttn_c.Content = Button_3_Image; Bttn_d.Content = Button_4_Image; Bttn_e.Content = Button_5_Image;

			}
		}
		public void AllesVast()
		{
			ClickRoll();
			ClickRoll();
			ClickRoll();
			ClickRoll();
			ClickRoll();
			Overlay.Visibility = Visibility.Visible;
			reverserollcount = 0;
		}
		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			Setup();
		}

		public void CheckBox5_Is_Checked()
		{
			PlaySoundRoll();
			if (CheckBox_5.IsChecked == true) { Lock_5.Visibility = Visibility.Visible; Vastgezet5 = true; }
			else { Lock_5.Visibility = Visibility.Hidden; Vastgezet5 = false; }
			if (CheckBox_1.IsChecked == true && CheckBox_2.IsChecked == true && CheckBox_3.IsChecked == true && CheckBox_4.IsChecked == true && CheckBox_5.IsChecked == true) { AllesVast(); }
			if (rollcount < 1) { MessageBox.Show("U moet eerst een keer hebben gedobbeld!", "Even wachten..."); CheckBox_5.IsChecked = false; Lock_5.Visibility = Visibility.Hidden; Vastgezet5 = false; }
		}

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			PlaySoundRoll();
			if (CheckBox_1.IsChecked == true) { Lock_1.Visibility = Visibility.Visible; Vastgezet1 = true; }
			else { Lock_1.Visibility = Visibility.Hidden; Vastgezet1 = false; }
			if (CheckBox_1.IsChecked == true && CheckBox_2.IsChecked == true && CheckBox_3.IsChecked == true && CheckBox_4.IsChecked == true && CheckBox_5.IsChecked == true) { AllesVast(); }
			if (rollcount < 1) { MessageBox.Show("U moet eerst een keer hebben gedobbeld!", "Even wachten..."); CheckBox_1.IsChecked = false; Lock_1.Visibility = Visibility.Hidden; Vastgezet1 = false; }
		}

		private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
		{
			PlaySoundRoll();
			if (CheckBox_2.IsChecked == true) { Lock_2.Visibility = Visibility.Visible; Vastgezet2 = true; }
			else { Lock_2.Visibility = Visibility.Hidden; Vastgezet2 = false; }
			if (CheckBox_1.IsChecked == true && CheckBox_2.IsChecked == true && CheckBox_3.IsChecked == true && CheckBox_4.IsChecked == true && CheckBox_5.IsChecked == true) { AllesVast(); }
			if (rollcount < 1) { MessageBox.Show("U moet eerst een keer hebben gedobbeld!", "Even wachten..."); CheckBox_2.IsChecked = false; Lock_2.Visibility = Visibility.Hidden; Vastgezet2 = false; }
		}

		private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
		{
			PlaySoundRoll();
			if (CheckBox_3.IsChecked == true) { Lock_3.Visibility = Visibility.Visible; Vastgezet3 = true; }
			else { Lock_3.Visibility = Visibility.Hidden; Vastgezet3 = false; }
			if (CheckBox_1.IsChecked == true && CheckBox_2.IsChecked == true && CheckBox_3.IsChecked == true && CheckBox_4.IsChecked == true && CheckBox_5.IsChecked == true) { AllesVast(); }
			if (rollcount < 1) { MessageBox.Show("U moet eerst een keer hebben gedobbeld!", "Even wachten..."); CheckBox_3.IsChecked = false; Lock_3.Visibility = Visibility.Hidden; Vastgezet3 = false; }
		}

		private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
		{
			PlaySoundRoll();
			if (CheckBox_4.IsChecked == true) { Lock_4.Visibility = Visibility.Visible; Vastgezet4 = true; }
			else { Lock_4.Visibility = Visibility.Hidden; Vastgezet4 = false; }
			if (CheckBox_1.IsChecked == true && CheckBox_2.IsChecked == true && CheckBox_3.IsChecked == true && CheckBox_4.IsChecked == true && CheckBox_5.IsChecked == true) { AllesVast(); }
			if (rollcount < 1) { MessageBox.Show("U moet eerst een keer hebben gedobbeld!", "Even wachten..."); CheckBox_4.IsChecked = false; Lock_4.Visibility = Visibility.Hidden; Vastgezet4 = false; }
		}

		private void PossibilityChecker()
		{
			Debug.WriteLine("----PossibilityChecker----");
			var stones = new[] { Stone_A, Stone_B, Stone_C, Stone_D, Stone_E }; // Assuming 5 dice for Yahtzee
			Debug.WriteLine(string.Join(", ", stones)); Debug.WriteLine(Convert.ToString(T_A) + Convert.ToString(T_B) + Convert.ToString(T_C) + Convert.ToString(T_D) + Convert.ToString(T_E));

			// Count occurrences of each number
			var counts = new Dictionary<string, int>
	{
		{ "ST1", stones.Count(x => x == "ST1") },
		{ "ST2", stones.Count(x => x == "ST2") },
		{ "ST3", stones.Count(x => x == "ST3") },
		{ "ST4", stones.Count(x => x == "ST4") },
		{ "ST5", stones.Count(x => x == "ST5") },
		{ "ST6", stones.Count(x => x == "ST6") }
	};

			//// Assign booleans based on dice values
			//Count_And_Add_Only_Aces_CanClick = counts["ST1"] > 0;
			//Count_And_Add_Only_Twos_CanClick = counts["ST2"] > 0;
			//Count_And_Add_Only_Threes_CanClick = counts["ST3"] > 0;
			//Count_And_Add_Only_Fours_CanClick = counts["ST4"] > 0;
			//Count_And_Add_Only_Fives_CanClick = counts["ST5"] > 0;
			//Count_And_Add_Only_Sixes_CanClick = counts["ST6"] > 0;

			//// Three of a Kind and Four of a Kind
			//Three_Of_A_Kind_TotalAllDices_CanClick = counts.Values.Any(x => x >= 3);
			//Four_Of_A_Kind_TotalAllDices_CanClick = counts.Values.Any(x => x >= 4);

			//// Full House (Three of one number and two of another)
			//Full_House_25_CanClick = counts.Values.Contains(3) && counts.Values.Contains(2);

			//// Low Straight (1, 2, 3, 4) and High Straight (2, 3, 4, 5, 6)
			//Low_Straight_30_CanClick = new[] { "ST1", "ST2", "ST3", "ST4" }.All(stone => stones.Contains(stone));
			//High_Straight_40_CanClick = new[] { "ST2", "ST3", "ST4", "ST5", "ST6" }.All(stone => stones.Contains(stone));

			//// Yahtzee (all dice the same)
			//Yahtzee_CanClick = counts.Values.Any(x => x == 5);

			//// Chance (always true)
			//Chance_Total_Of_All_Dices_CanClick = true;

			
		}
		public void LabelSetter()
		{
			// Update Upper Section Labels
			AcesLabel.Content = Count_And_Add_Only_Aces_Score.ToString();
			TwosLabel.Content = Count_And_Add_Only_Twos_Score.ToString();
			ThreesLabel.Content = Count_And_Add_Only_Threes_Score.ToString();
			FoursLabel.Content = Count_And_Add_Only_Fours_Score.ToString();
			FivesLabel.Content = Count_And_Add_Only_Fives_Score.ToString();
			SixesLabel.Content = Count_And_Add_Only_Sixes_Score.ToString();

			// Calculate Upper Section Total and Bonus
			int UpperTotalScore = Count_And_Add_Only_Aces_Score + Count_And_Add_Only_Twos_Score +
								  Count_And_Add_Only_Threes_Score + Count_And_Add_Only_Fours_Score +
								  Count_And_Add_Only_Fives_Score + Count_And_Add_Only_Sixes_Score;

			// Assign bonus if Upper Section score is 63 or more
			BonusLabel.Content = UpperTotalScore >= 63 ? "35" : "0";
			int TotalOfUpperSectionScore = UpperTotalScore + (UpperTotalScore >= 63 ? 35 : 0);
			UpperSectionTotalLabel.Content = TotalOfUpperSectionScore.ToString();

			// Update Lower Section Labels
			ThreeOfAKindLabel.Content = Three_Of_A_Kind_TotalAllDices_Score.ToString();
			FourOfAKindLabel.Content = Four_Of_A_Kind_TotalAllDices_Score.ToString();
			FullHouseLabel.Content = Full_House_25_Score.ToString();
			LowStraightLabel.Content = Low_Straight_30_Score.ToString();
			HighStraightLabel.Content = High_Straight_40_Score.ToString();
			YahtzeeLabel.Content = Yahtzee_Score.ToString();
			ChanceLabel.Content = Chance_Total_Of_All_Dices_Score.ToString();
			YahtzeeBonusLabel.Content = Yahtzee_Bonus_Score.ToString();

			// Calculate Lower Section Total
			int LowerTotalScore = Three_Of_A_Kind_TotalAllDices_Score + Four_Of_A_Kind_TotalAllDices_Score +
								  Full_House_25_Score + Low_Straight_30_Score + High_Straight_40_Score +
								  Yahtzee_Score + Chance_Total_Of_All_Dices_Score + Yahtzee_Bonus_Score;
			LowerTotalLabel.Content = LowerTotalScore.ToString();

			// Calculate Grand Total (Upper + Lower)
			int GrandTotalScore = TotalOfUpperSectionScore + LowerTotalScore;
			GrandTotalLabel.Content = GrandTotalScore.ToString();
		}


		private void DebugPossibilityLog()
		{
			Debug.WriteLine($"Count_And_Add_Only_Aces_CanClick: {Count_And_Add_Only_Aces_CanClick}");
			Debug.WriteLine($"Count_And_Add_Only_Twos_CanClick: {Count_And_Add_Only_Twos_CanClick}");
			Debug.WriteLine($"Count_And_Add_Only_Threes_CanClick: {Count_And_Add_Only_Threes_CanClick}");
			Debug.WriteLine($"Count_And_Add_Only_Fours_CanClick: {Count_And_Add_Only_Fours_CanClick}");
			Debug.WriteLine($"Count_And_Add_Only_Fives_CanClick: {Count_And_Add_Only_Fives_CanClick}");
			Debug.WriteLine($"Count_And_Add_Only_Sixes_CanClick: {Count_And_Add_Only_Sixes_CanClick}");
			Debug.WriteLine($"Three_Of_A_Kind_TotalAllDices_CanClick: {Three_Of_A_Kind_TotalAllDices_CanClick}");
			Debug.WriteLine($"Four_Of_A_Kind_TotalAllDices_CanClick: {Four_Of_A_Kind_TotalAllDices_CanClick}");
			Debug.WriteLine($"Full_House_25_CanClick: {Full_House_25_CanClick}");
			Debug.WriteLine($"Low_Straight_30_CanClick: {Low_Straight_30_CanClick}");
			Debug.WriteLine($"High_Straight_40_CanClick: {High_Straight_40_CanClick}");
			Debug.WriteLine($"Yahtzee_CanClick: {Yahtzee_CanClick}");
			Debug.WriteLine($"Chance_Total_Of_All_Dices_CanClick: {Chance_Total_Of_All_Dices_CanClick}");
		}

		private MediaPlayer player;
		private MediaPlayer player2;
		private MediaPlayer player3;

		private void PlaySound()
		{
			// Initialize the MediaPlayer instance
			player = new MediaPlayer();

			var uri = new Uri(@"Assets/game.mp3", UriKind.RelativeOrAbsolute);
			player.Open(uri);
			player.Play();
			player.Volume = 0;

			// Loop the music when it ends
			player.MediaEnded += (sender, e) =>
			{
				player.Position = TimeSpan.Zero; // Reset to the start
				player.Play(); // Play again
				player.Volume = 0;
			};
		}
		private void PlaySoundRoll()
		{

			// Initialize the MediaPlayer instance
			player2 = new MediaPlayer();
			player2.Volume = rollvolume;
			player2.Position = TimeSpan.Zero;
			var uri = new Uri(@"Assets/roll.wav", UriKind.RelativeOrAbsolute);
			player2.Open(uri);
			player2.Play();

			// Loop the music when it ends
			player.MediaEnded += (sender, e) =>
			{
				player.Position = TimeSpan.Zero; // Reset to the start
			};
		}private void PlaySoundWrite()
		{

			// Initialize the MediaPlayer instance
			player3 = new MediaPlayer();
			player3.Position = TimeSpan.Zero;
			var uri = new Uri(@"Assets/write.mp3", UriKind.RelativeOrAbsolute);
			player3.Open(uri);
			player3.Play();

			// Loop the music when it ends
			player.MediaEnded += (sender, e) =>
			{
				player.Position = TimeSpan.Zero; // Reset to the start
			};
		}
		//Hieronder de mogelijkheden aan punten opslaan

		private void Count_And_Add_Only_Aces(object sender, RoutedEventArgs e)
		{
			if (T_A == 1 || T_B == 1 || T_C == 1 || T_D == 1 || T_E == 1) { Count_And_Add_Only_Aces_CanClick = true; }
			else { Count_And_Add_Only_Aces_CanClick = false;}
			//Telt alle dobbelstenen met een waarde van 1 op en voegt deze toe aan de score
			if (!Count_And_Add_Only_Aces_CanClick) { MessageBox.Show("U kunt deze knop nog niet gebruiken!", "Even wachten...");

			}
			else { PlaySoundWrite();
				if (!WeHaveDoneThisAlready1)
				{
					if (T_A == 1) { Count_And_Add_Only_Aces_Score++; }
					if (T_B == 1) { Count_And_Add_Only_Aces_Score++; }
					if (T_C == 1) { Count_And_Add_Only_Aces_Score++; }
					if (T_D == 1) { Count_And_Add_Only_Aces_Score++; }
					if (T_E == 1) { Count_And_Add_Only_Aces_Score++; }
					Debug.WriteLine("Aces Score Has Been Updated To: " + Count_And_Add_Only_Aces_Score);
					Label label = new Label(); label = FindName("AcesLabel") as Label; label.Content = Count_And_Add_Only_Aces_Score.ToString();

					bool WeHaveDoneThisAlready1 = true;

					ResetCanRoll();
					WeHaveDoneThisAlready1 = true;
				}
				else
				{
					MessageBox.Show("U kunt niet zomaar een zet veranderen!");
				}
				
			}
		}

		private void Count_And_Add_Only_Twos(object sender, RoutedEventArgs e)
		{
			//Telt alle dobbelstenen met een waarde van 2 op en voegt deze toe aan de score
			if (T_A == 2 || T_B == 2 || T_C == 2 || T_D == 2 || T_E == 2) { Count_And_Add_Only_Twos_CanClick = true; }
			else { Count_And_Add_Only_Twos_CanClick = false; }
			if (!Count_And_Add_Only_Twos_CanClick)
			{
				MessageBox.Show("U kunt deze knop nog niet gebruiken!", "Even wachten...");

			}
			else
			{
				PlaySoundWrite();
				if (!WeHaveDoneThisAlready2)
				{
					if (T_A == 2) { Count_And_Add_Only_Twos_Score +=2; }
					if (T_B == 2) { Count_And_Add_Only_Twos_Score += 2; }
					if (T_C == 2) { Count_And_Add_Only_Twos_Score += 2; }
					if (T_D == 2) { Count_And_Add_Only_Twos_Score += 2; }
					if (T_E == 2) { Count_And_Add_Only_Twos_Score += 2; }
					Debug.WriteLine("Aces Score Has Been Updated To: " + Count_And_Add_Only_Twos_Score);
					Label label = new Label(); label = FindName("TwosLabel") as Label; label.Content = Count_And_Add_Only_Twos_Score.ToString();

					bool WeHaveDoneThisAlready2 = true;

					ResetCanRoll();
					WeHaveDoneThisAlready2 = true;
				}
				else
				{
					MessageBox.Show("U kunt niet zomaar een zet veranderen!");
				}

			}
		}

		private void Count_And_Add_Only_Threes(object sender, RoutedEventArgs e)
		{
			if (T_A == 3 || T_B == 3 || T_C == 3 || T_D == 3 || T_E == 3) { Count_And_Add_Only_Threes_CanClick = true; }
			//Telt alle dobbelstenen met een waarde van 3 op en voegt deze toe aan de score
			if (!Count_And_Add_Only_Threes_CanClick) { MessageBox.Show("U kunt deze knop nog niet gebruiken!", "Even wachten..."); }
			else { PlaySoundWrite(); 
				if (T_A == 3 || T_B == 3 || T_C == 3 || T_D == 3 || T_E == 3 ) { Count_And_Add_Only_Threes_CanClick = true; }
				else { Count_And_Add_Only_Threes_CanClick = false; }
				if (!Count_And_Add_Only_Threes_CanClick)
				{
					MessageBox.Show("U kunt deze knop nog niet gebruiken!", "Even wachten...");

				}
				else
				{
					PlaySoundWrite();
					if (!WeHaveDoneThisAlready3)
					{
						if (T_A == 3) { Count_And_Add_Only_Threes_Score += 3; }
						if (T_B == 3) { Count_And_Add_Only_Threes_Score += 3; }
						if (T_C == 3) { Count_And_Add_Only_Threes_Score += 3; }
						if (T_D == 3) { Count_And_Add_Only_Threes_Score += 3; }
						if (T_E == 3) { Count_And_Add_Only_Threes_Score += 3; }
						Debug.WriteLine("Aces Score Has Been Updated To: " + Count_And_Add_Only_Threes_Score);
						Label label = new Label(); label = FindName("ThreesLabel") as Label; label.Content = Count_And_Add_Only_Threes_Score.ToString();

						bool WeHaveDoneThisAlready3 = true;

						ResetCanRoll();
						WeHaveDoneThisAlready3 = true;
					}
					else
					{
						MessageBox.Show("U kunt niet zomaar een zet veranderen!");
					}

				}

			}
		}

		private void Count_And_Add_Only_Fours(object sender, RoutedEventArgs e)
		{
			if (T_A == 4 || T_B == 4 || T_C == 4 || T_D == 4 || T_E == 4) { Count_And_Add_Only_Fours_CanClick = true; }
			if (!Count_And_Add_Only_Fours_CanClick) { MessageBox.Show("U kunt deze knop nog niet gebruiken!", "Even wachten..."); }
			else
			{
				PlaySoundWrite();
				if (T_A == 4 || T_B == 4 || T_C == 4 || T_D == 4 || T_E == 4) { Count_And_Add_Only_Fours_CanClick = true; }
				else { Count_And_Add_Only_Fours_CanClick = false; }
				if (!Count_And_Add_Only_Fours_CanClick)
				{
					MessageBox.Show("U kunt deze knop nog niet gebruiken!", "Even wachten...");

				}
				else
				{
					PlaySoundWrite();
					if (!WeHaveDoneThisAlready4)
					{
						if (T_A == 4) { Count_And_Add_Only_Fours_Score += 4; }
						if (T_B == 4) { Count_And_Add_Only_Fours_Score += 4; }
						if (T_C == 4) { Count_And_Add_Only_Fours_Score += 4; }
						if (T_D == 4) { Count_And_Add_Only_Fours_Score += 4; }
						if (T_E == 4) { Count_And_Add_Only_Fours_Score += 4; }
						Debug.WriteLine("Aces Score Has Been Updated To: " + Count_And_Add_Only_Fours_Score);
						Label label = new Label(); label = FindName("FoursLabel") as Label; label.Content = Count_And_Add_Only_Fours_Score.ToString();

						bool WeHaveDoneThisAlready4 = true;

						ResetCanRoll();
						WeHaveDoneThisAlready4 = true;
					}
					else
					{
						MessageBox.Show("U kunt niet zomaar een zet veranderen!");
					}

				}

			}
		}

		private void Count_And_Add_Only_Fives(object sender, RoutedEventArgs e)
		{
			if (T_A == 5 || T_B == 5 || T_C == 5 || T_D == 5 || T_E == 5) { Count_And_Add_Only_Fives_CanClick = true; }
			if (!Count_And_Add_Only_Fives_CanClick) { MessageBox.Show("U kunt deze knop nog niet gebruiken!", "Even wachten..."); }
			else
			{
				PlaySoundWrite();
				if (T_A == 5 || T_B == 5 || T_C == 5 || T_D == 5 || T_E == 5) { Count_And_Add_Only_Fives_CanClick = true; }
				else { Count_And_Add_Only_Fives_CanClick = false; }
				if (!Count_And_Add_Only_Fives_CanClick)
				{
					MessageBox.Show("U kunt deze knop nog niet gebruiken!", "Even wachten...");

				}
				else
				{
					PlaySoundWrite();
					if (!WeHaveDoneThisAlready5)
					{
						if (T_A == 5) { Count_And_Add_Only_Fives_Score += 5; }
						if (T_B == 5) { Count_And_Add_Only_Fives_Score += 5; }
						if (T_C == 5) { Count_And_Add_Only_Fives_Score += 5; }
						if (T_D == 5) { Count_And_Add_Only_Fives_Score += 5; }
						if (T_E == 5) { Count_And_Add_Only_Fives_Score += 5; }
						Debug.WriteLine("Aces Score Has Been Updated To: " + Count_And_Add_Only_Fives_Score);
						Label label = new Label(); label = FindName("FivesLabel") as Label; label.Content = Count_And_Add_Only_Fives_Score.ToString();

						bool WeHaveDoneThisAlready5 = true;

						ResetCanRoll();
						WeHaveDoneThisAlready5 = true;
					}
					else
					{
						MessageBox.Show("U kunt niet zomaar een zet veranderen!");
					}

				}

			}
		}

		private void Count_And_Add_Only_Sixes(object sender, RoutedEventArgs e)
		{
			if (T_A == 6 || T_B == 6 || T_C == 6 || T_D == 6 || T_E == 6) { Count_And_Add_Only_Sixes_CanClick = true; }
			if (!Count_And_Add_Only_Sixes_CanClick) { MessageBox.Show("U kunt deze knop nog niet gebruiken!", "Even wachten..."); }
			else
			{
				PlaySoundWrite();
				if (T_A == 6 || T_B == 6 || T_C == 6 || T_D == 6 || T_E == 6) { Count_And_Add_Only_Sixes_CanClick = true; }
				else { Count_And_Add_Only_Sixes_CanClick = false; }
				if (!Count_And_Add_Only_Sixes_CanClick)
				{
					MessageBox.Show("U kunt deze knop nog niet gebruiken!", "Even wachten...");

				}
				else
				{
					PlaySoundWrite();
					if (!WeHaveDoneThisAlready6)
					{
						if (T_A == 6) { Count_And_Add_Only_Sixes_Score += 6; }
						if (T_B == 6) { Count_And_Add_Only_Sixes_Score += 6; }
						if (T_C == 6) { Count_And_Add_Only_Sixes_Score += 6; }
						if (T_D == 6) { Count_And_Add_Only_Sixes_Score += 6; }
						if (T_E == 6) { Count_And_Add_Only_Sixes_Score += 6; }
						Debug.WriteLine("Aces Score Has Been Updated To: " + Count_And_Add_Only_Sixes_Score);
						Label label = new Label(); label = FindName("SixesLabel") as Label; label.Content = Count_And_Add_Only_Sixes_Score.ToString();

						bool WeHaveDoneThisAlready6 = true;

						ResetCanRoll();
						WeHaveDoneThisAlready6 = true;
					}
					else
					{
						MessageBox.Show("U kunt niet zomaar een zet veranderen!");
					}

				}

			}
		}

		private void Three_Of_A_Kind_TotalAllDices(object sender, RoutedEventArgs e)
		{
			Three_Of_A_Kind_TotalAllDices_CanClick = true;

			String TMP_CHECKSUM = "";
			TMP_CHECKSUM += Convert.ToString(T_A);
			TMP_CHECKSUM += Convert.ToString(T_B);
			TMP_CHECKSUM += Convert.ToString(T_C);
			TMP_CHECKSUM += Convert.ToString(T_D);
			TMP_CHECKSUM += Convert.ToString(T_E);

			Dictionary<int, int> diceCount = TMP_CHECKSUM.GroupBy(c => c)
														 .ToDictionary(g => int.Parse(g.Key.ToString()), g => g.Count());

			// Check if any value occurs 3 or more times
			if (diceCount.Values.Any(count => count >= 3))
			{
				int total = TMP_CHECKSUM.Sum(c => int.Parse(c.ToString()));
				Three_Of_A_Kind_TotalAllDices_Score = total;
				ThreeOfAKindLabel.Content = total.ToString();
				ResetCanRoll();
			}
			else
			{
				MessageBox.Show("No three of a kind!");
			}
		}

		private void Four_Of_A_Kind_TotalAllDices(object sender, RoutedEventArgs e)
		{
			Four_Of_A_Kind_TotalAllDices_CanClick = true;

			String TMP_CHECKSUM = "";
			TMP_CHECKSUM += Convert.ToString(T_A);
			TMP_CHECKSUM += Convert.ToString(T_B);
			TMP_CHECKSUM += Convert.ToString(T_C);
			TMP_CHECKSUM += Convert.ToString(T_D);
			TMP_CHECKSUM += Convert.ToString(T_E);

			Dictionary<int, int> diceCount = TMP_CHECKSUM.GroupBy(c => c)
														 .ToDictionary(g => int.Parse(g.Key.ToString()), g => g.Count());

			// Check if any value occurs 4 or more times
			if (diceCount.Values.Any(count => count >= 4))
			{
				int total = TMP_CHECKSUM.Sum(c => int.Parse(c.ToString()));
				Four_Of_A_Kind_TotalAllDices_Score = total;
				FourOfAKindLabel.Content = total.ToString();
				ResetCanRoll();
			}
			else
			{
				MessageBox.Show("No four of a kind!");
			}
		}

		private void Full_House_25(object sender, RoutedEventArgs e)
		{
			Full_House_25_CanClick = true;

			String TMP_CHECKSUM = "";
			TMP_CHECKSUM += Convert.ToString(T_A);
			TMP_CHECKSUM += Convert.ToString(T_B);
			TMP_CHECKSUM += Convert.ToString(T_C);
			TMP_CHECKSUM += Convert.ToString(T_D);
			TMP_CHECKSUM += Convert.ToString(T_E);

			Dictionary<int, int> diceCount = TMP_CHECKSUM.GroupBy(c => c)
														 .ToDictionary(g => int.Parse(g.Key.ToString()), g => g.Count());

			bool hasThreeOfAKind = diceCount.ContainsValue(3);
			bool hasPair = diceCount.ContainsValue(2);

			if (hasThreeOfAKind && hasPair)
			{
				Full_House_25_Score = 25;
				FullHouseLabel.Content = "25";
				ResetCanRoll();
			}
			else
			{
				MessageBox.Show("No full house!");
			}
		}

		private void Low_Straight_30(object sender, RoutedEventArgs e)
		{
			Low_Straight_30_CanClick = true;

			String TMP_CHECKSUM = "";
			TMP_CHECKSUM += Convert.ToString(T_A);
			TMP_CHECKSUM += Convert.ToString(T_B);
			TMP_CHECKSUM += Convert.ToString(T_C);
			TMP_CHECKSUM += Convert.ToString(T_D);
			TMP_CHECKSUM += Convert.ToString(T_E);

			// Convert the string into a set of integers
			HashSet<int> rolledNumbers = TMP_CHECKSUM.Select(c => int.Parse(c.ToString())).ToHashSet();

			// Small straight requires at least 4 consecutive numbers out of {1, 2, 3, 4, 5}
			List<HashSet<int>> possibleSmallStraights = new List<HashSet<int>> {
		new HashSet<int> { 1, 2, 3, 4 },
		new HashSet<int> { 2, 3, 4, 5 },
		new HashSet<int> { 3, 4, 5, 6 }
	};

			if (possibleSmallStraights.Any(straight => straight.IsSubsetOf(rolledNumbers)))
			{
				Low_Straight_30_Score = 30;
				LowStraightLabel.Content = "30";
				ResetCanRoll();
			}
			else
			{
				MessageBox.Show("No low straight!");
			}
		}

		private void High_Straight_40(object sender, RoutedEventArgs e)
		{
			High_Straight_40_CanClick = true;

			String TMP_CHECKSUM = "";
			TMP_CHECKSUM += Convert.ToString(T_A);
			TMP_CHECKSUM += Convert.ToString(T_B);
			TMP_CHECKSUM += Convert.ToString(T_C);
			TMP_CHECKSUM += Convert.ToString(T_D);
			TMP_CHECKSUM += Convert.ToString(T_E);

			HashSet<int> rolledNumbers = TMP_CHECKSUM.Select(c => int.Parse(c.ToString())).ToHashSet();

			// High straight requires {2, 3, 4, 5, 6}
			HashSet<int> highStraight = new HashSet<int> { 2, 3, 4, 5, 6 };

			if (highStraight.IsSubsetOf(rolledNumbers))
			{
				High_Straight_40_Score = 40;
				HighStraightLabel.Content = "40";
				ResetCanRoll();
			}
			else
			{
				MessageBox.Show("No high straight!");
			}
		}

		private void Yahtzee(object sender, RoutedEventArgs e)
		{
			Yahtzee_CanClick = true;

			String TMP_CHECKSUM = "";
			TMP_CHECKSUM += Convert.ToString(T_A);
			TMP_CHECKSUM += Convert.ToString(T_B);
			TMP_CHECKSUM += Convert.ToString(T_C);
			TMP_CHECKSUM += Convert.ToString(T_D);
			TMP_CHECKSUM += Convert.ToString(T_E);

			// All dice must be the same value
			if (TMP_CHECKSUM.Distinct().Count() == 1)
			{
				Yahtzee_Score = 50;
				YahtzeeLabel.Content = "50";
				ResetCanRoll();
			}
			else
			{
				MessageBox.Show("No Yahtzee!");
			}
		}

		private void Chance_Total_Of_All_Dices(object sender, RoutedEventArgs e)
		{
			Chance_Total_Of_All_Dices_CanClick = true;

			String TMP_CHECKSUM = "";
			TMP_CHECKSUM += Convert.ToString(T_A);
			TMP_CHECKSUM += Convert.ToString(T_B);
			TMP_CHECKSUM += Convert.ToString(T_C);
			TMP_CHECKSUM += Convert.ToString(T_D);
			TMP_CHECKSUM += Convert.ToString(T_E);

			int total = TMP_CHECKSUM.Sum(c => int.Parse(c.ToString()));
			Chance_Total_Of_All_Dices_Score = total;
			ChanceLabel.Content = total.ToString();
			ResetCanRoll();
		}

		private void Yahtzee_Bonus(object sender, RoutedEventArgs e)
		{
			Yahtzee_Bonus_CanClick = true;

			String TMP_CHECKSUM = "";
			TMP_CHECKSUM += Convert.ToString(T_A);
			TMP_CHECKSUM += Convert.ToString(T_B);
			TMP_CHECKSUM += Convert.ToString(T_C);
			TMP_CHECKSUM += Convert.ToString(T_D);
			TMP_CHECKSUM += Convert.ToString(T_E);

			// All dice must have the same value
			if (TMP_CHECKSUM.Distinct().Count() == 1)
			{
				Yahtzee_Bonus_Score += 100;  // Bonus adds 100 points
				YahtzeeBonusLabel.Content = Yahtzee_Bonus_Score.ToString();
				ResetCanRoll();
			}
			else
			{
				MessageBox.Show("No Yahtzee bonus!");
			}
		}




		private void CheckBox_Checked_5_Late(object sender, RoutedEventArgs e)
		{

			CheckBox5_Is_Checked();
		}
	}
}