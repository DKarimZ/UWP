using UWPFoodBook.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPFoodBook
{
	/// <summary>
	/// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{

		private MainVM VM = new MainVM();

		public MainPage()                                                                                                             
		{                                                                                           
			InitializeComponent();                                                                                                                  
		}                                                                                                                        

		private void Button_Click(object sender, RoutedEventArgs e)                                 
		{                                           
			VM.Titre = "HELLO WORLD !!!";                                                            
		}

		private void Calculer_Click(object sender, RoutedEventArgs e)
		{
			VM.Result = VM.Calculate();
		}
	} 
}
 