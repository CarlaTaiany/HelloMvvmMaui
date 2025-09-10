using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;


namespace HelloMvvmMaui.ViewModels
{
    //ViewModel para conversar com  a MainPage.xaml (minha View)
   public class MainViewModel: INotifyPropertyChanged
    //Quando uma propriedade mudar, a View (MainPage.xaml) será notificada
   {
        private string _nome;
        private string _saudacao;

        //Propreidade que vai conversar com o nosso Entry (MainPage.xaml)
        public string Nome
        {
            get => _nome;
            set 
            { 
                if(_nome != value)
                {
                    _nome = value;
                    OnPropetyChanged(); //Notifica a View que a propriedade mudou

                    CumprimentarCommand.ChangeCanExecute(); //Atualiza o estado do comando
                }                
            }
        }

        //Propreidade que vai conversar com o nosso Label (MainPage.xaml)
        public string Saudacao
        {
            get => _saudacao;
            set 
            { 
                if(_saudacao != value)
                {
                    _saudacao = value;
                    //Notifica a View que a propriedade mudou
                    OnPropetyChanged(); 
                }                
            }
        }

        public Command CumprimentarCommand { get; }
        //Comando para o botão Cumprimentar
        
        public MainViewModel()
        {
            //Define o que o Cammand faz e qaundo executar
            CumprimentarCommand = new Command(execute: () =>
            {
                //Ação do comando de mostrar a saudação
                Saudacao = $"Olá, {Nome}!";
            },

            //Habilita o boatão se o Nome não for vazio ou nulo
            canExecute: () => !string.IsNullOrWhiteSpace(Nome) 
            );
        }

        //Suporte do meu biding
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropetyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs(propName));
           
   
        
            


        }

}
