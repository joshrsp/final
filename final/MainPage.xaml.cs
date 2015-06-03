using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;


namespace final
{
    public partial class MainPage : PhoneApplicationPage
    {
        ShellTile appTitle = ShellTile.ActiveTiles.First();
        int i = 0, valorCategoria = 0, valorSubcategoria=0,siguiente=0,preguntas=0,branch=0,numerovalidado=0;
        StackPanel Panel;
        Button btnClick, btnClick2, btnClick3;
        ListBox list,list2,list3;
        List<RootObject> root1;
        List<RootObjectProcesos> root2;
        List<RootObjectPasos> root3;
        TextBlock texto1;
        List<String> respuesta = new List<string>();
        TextBox txtbox;
        // Constructor
        public MainPage()
        {  
            InitializeComponent();
            
            if (appTitle != null)
            {
                StandardTileData tileData = new StandardTileData();

                tileData.Title = "Mi Aplicación";
                tileData.Count = 7;
                //tileData.BackgroundImage = new Uri("Imagenes/sl4logo.png", UriKind.Relative);
                tileData.BackContent = "Atrás";
                tileData.BackTitle = "Procesos";
                //tileData.BackBackgroundImage = new Uri("Imagenes/WPLogo.png", UriKind.Relative);


                appTitle.Update(tileData);
            }
            Panel = new StackPanel();
            texto1 = new TextBlock();
            texto1.Text = "Escoge tu categoria";
            texto1.FontSize=30;
            texto1.Foreground = new SolidColorBrush(Color.FromArgb(255,212,106,106));
            texto1.Margin = new Thickness(0, 0, 0, 50);
            texto1.TextWrapping = TextWrapping.Wrap;
            Panel.Children.Add(texto1);
            btnClick3 = new Button();
            btnClick3.Content = "Siguiente";
            btnClick3.Width = 222;
            btnClick3.Height = 76;
            btnClick3.Background = new SolidColorBrush(Color.FromArgb(255,127, 71, 71));
            txtbox = new TextBox();
           // for (i = 0; i < 5; i++)
           // {
               
             //   Panel.Loaded += new RoutedEventHandler(MainPage_Loaded);
               
           // }
            
           // btnClick.Click += new RoutedEventHandler(traerJson);
            traerJson();
            Panel.Background = new SolidColorBrush(Color.FromArgb(255, 85, 0, 0));
            LayoutRoot.Children.Add(Panel);
            
           
        }

        public void traerJson()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
           // ProgressBarRequest.Visibility = System.Windows.Visibility.Visible;
            // webClient.DownloadStringAsync(new Uri("https://dl.dropboxusercontent.com/u/61070317/procesos.txt"));
            webClient.DownloadStringAsync(new Uri("https://dynamicformapi.herokuapp.com/groups.json"));
        }

        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
           try
            {
               if (!string.IsNullOrEmpty(e.Result))
               {
                   //MessageBox.Show(e.Result); 
                   
                    //Parse JSON result as POCO 
                   root1 = JsonConvert.DeserializeObject<List<RootObject>>(e.Result);
                  //Current_Condition currentCondition = root1.Comida.helado.pregunta2.pregunta[0];
                //  MessageBox.Show(""+root1.Comida.helado.Count);
                  
                  //MessageBox.Show(""+root1.procesos[0].Comida.helado[0]);
                  list = new ListBox();
                  
                  for (int o = 0; o < root1.Count;o++ )
                  {
                      list.Items.Add("" + root1[o].name+"\n\n");
                      
                  }
                  
                  list.Margin= new Thickness(0, 0, 0, 50);
                  btnClick = new Button();
                  btnClick.Content = "Click categoria";
                  btnClick.Width = 220;
                  btnClick.Height = 76;
                  btnClick.Background = new SolidColorBrush(Color.FromArgb(255, 127, 71, 71));
                  btnClick.Click += new RoutedEventHandler(escoger);
                  Panel.Children.Add(list);
                  Panel.Children.Add(btnClick);
                 
                 // MessageBox.Show("" +root1.procesos[0].Comida.helado[1].pregunta);
                  /* foreach(var j in root1.procesos)
                   {
                      // MessageBox.Show(""+j.Comida.helado.Count);
                       
                   }*/

                  /*  this.DataContext = root1;*/

                }
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            
                TextBlock txtmsg = new TextBlock();
                txtmsg.Text = "New Program."+i;
                txtmsg.TextWrapping = TextWrapping.Wrap;
               // txtmsg.Margin = new Thickness(10 , 20 + (i * 30), 10, 10);
                //Button btnClick = new Button();
                //btnClick.Content = "Click";
                TextBox txtbox = new TextBox();
                txtbox.Text = " ";
                txtbox.Width = 212;
                txtbox.Height = 66;
              //  txtbox.Margin = new Thickness(10, 20 + (i * 100), 10, 10);
                ListBox list = new ListBox();
                list.Items.Add("prueba");
                list.Items.Add("prueba2");
                Panel.Children.Add(txtmsg);
                Panel.Children.Add(txtbox);
                Panel.Children.Add(list);
                //ContentPanel.Children.Add(btnClick);

            
        }
       public void escoger(object sender, RoutedEventArgs e)
        {   
            if (list.SelectedValue != null)
            {
                /*string seleccion = ""+list.SelectedValue;
                int valor = list.SelectedIndex;
                MessageBox.Show("Proceso seleccionado " + list.SelectedValue);
                list.IsEnabled=false;
                btnClick.IsEnabled = false;
                list2 = new ListBox();
                //mientras averiguo
                if (valor == 0)
                {
                    //for (int o = 0; o < root1.procesos[0].comida.Count; o++)
                    // {
                    list2.Items.Add("" + root1.procesos[0].comida.nombre2);

                    //  }
                }
                else
                {
                    if(valor==1)
                    {
                        list2.Items.Add("" + root1.procesos[0].Mantenimiento.nombre2);
                    }
                }
                btnClick2 = new Button();
                btnClick2.Content= "Click";
                btnClick2.Width = 212;
                btnClick2.Height = 66;
                btnClick2.Click += new RoutedEventHandler(escoger);
                Panel.Children.Add(list2);
                Panel.Children.Add(btnClick2);*/
                texto1.Text = "Seleccione subcategoria";
                valorCategoria = list.SelectedIndex+1;
                list.Visibility = Visibility.Collapsed;
                btnClick.Visibility = Visibility.Collapsed;
                
                traerJsonSub();

            }
            else
            {
                MessageBox.Show("Seleccione un proceso");
            }

        }
       public void traerJsonSub()
       {
           WebClient webClient = new WebClient();
           webClient.DownloadStringCompleted += webClient_DownloadStringCompletedSub;
           webClient.DownloadStringAsync(new Uri("https://dynamicformapi.herokuapp.com/procedures.json"));
       }

       void webClient_DownloadStringCompletedSub(object sender, DownloadStringCompletedEventArgs e)
       {
           try
           {
               if (!string.IsNullOrEmpty(e.Result))
               {
                  
                   root2 = JsonConvert.DeserializeObject<List<RootObjectProcesos>>(e.Result);
                   
                   list2 = new ListBox();
                   list2.Margin = new Thickness(0, 0, 0, 50);
                   for (int o = 0; o < root2.Count; o++)
                   {
                       if(valorCategoria==root2[o].group_id)
                       {
                           //list2.Items.Add("" + root2[o].name+"\n"+root2[0].description);
                           list2.Items.Add("" + root2[o].name+"\n\n");
                       }
                       
                   }

                   btnClick2 = new Button();
                   btnClick2.Content = "Click subcategoria";
                   btnClick2.Width = 270;
                   btnClick2.Height = 76;
                   btnClick2.Background = new SolidColorBrush(Color.FromArgb(255, 127, 71, 71));
                   btnClick2.Click += new RoutedEventHandler(escogerSub);
                   //list2.Margin = new Thickness(10, 10, 10, 10);
                   Panel.Children.Add(list2);
                   Panel.Children.Add(btnClick2);

               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }


       }

       public void escogerSub(object sender, RoutedEventArgs e)
       {
           if (list2.SelectedValue != null)
           {
               
               string nombre = ""+list2.SelectedItem;
               nombre = nombre.Trim();
               for (int o = 0; o < root2.Count; o++)
               {
                   if (nombre.Equals(root2[o].name.Trim()))
                   {
                       valorSubcategoria = root2[o].procedure_id;//
                   }

               }
               
               list2.Visibility = Visibility.Collapsed;
               btnClick2.Visibility = Visibility.Collapsed;
               traerJsonPasos();

           }
           else
           {
               MessageBox.Show("Seleccione un subproceso");
           }

       }

       public void traerJsonPasos()
       {
           WebClient webClient = new WebClient();
           webClient.DownloadStringCompleted += webClient_DownloadStringCompletedPasos;
           webClient.DownloadStringAsync(new Uri("https://dynamicformapi.herokuapp.com/steps/by_procedure/" + valorSubcategoria + ".json"));
       }
      

       void webClient_DownloadStringCompletedPasos(object sender, DownloadStringCompletedEventArgs e)
       {
           try
           {
               if (!string.IsNullOrEmpty(e.Result))
               {

                   root3 = JsonConvert.DeserializeObject<List<RootObjectPasos>>(e.Result);

                  /* list3 = new ListBox();
                   for (int o = 0; o < root3.Count; o++)
                   {
                       if (valorSubcategoria == root3[o].procedure_id)
                       {
                           list3.Items.Add("" + root3[o].content);
                       }

                   }*/

                 /*  btnClick2 = new Button();
                   btnClick2.Content = "Click subcategoria";
                   btnClick2.Width = 270;
                   btnClick2.Height = 66;
                   //btnClick2.Click += new RoutedEventHandler(escoger);
                   Panel.Children.Add(list2);
                   Panel.Children.Add(btnClick2);*/
                   list3 = new ListBox();
                   list3.Margin = new Thickness(0, 0, 0, 50);
                    traerJsontodos();
                 
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
        }

       public void llamar(object sender, RoutedEventArgs e)
       {
           
           traerJsontodos();
       }
       public void traerJsontodos()
       {
           
          try
          {
           Contenido root4 = JsonConvert.DeserializeObject<Contenido>(root3[siguiente].content);
           
           /*if(!txtbox.Text.Equals(""))
           {
               respuesta.Add(txtbox.Text);
               txtbox.Text = "";
           }*/
           if (root4.Fields[preguntas].field_type.Equals("0") || root4.Fields[preguntas].field_type.Equals("1"))
           {
               if (list3.Items.Count > 0)
               {
                   respuesta.Add("" + list3.SelectedItem);
                   
               }

               

               list3.Items.Clear();
               texto1.Text = "" + root4.Fields[preguntas].caption;
               for (int j = 0; j < root4.Fields[preguntas].possible_values.Count; j++)
               {
                   
                   list3.Items.Add(root4.Fields[preguntas].possible_values[j]);
               }
               preguntas = preguntas + 1;

               if (preguntas < root4.Fields.Count)
               {
                   btnClick3.Click -= new RoutedEventHandler(siguientePaso);
                   btnClick3.Click -= new RoutedEventHandler(llamar);
                   btnClick3.Click += new RoutedEventHandler(llamar);
               }
               else
               {
                   btnClick3.Click -= new RoutedEventHandler(siguientePaso);
                   btnClick3.Click -= new RoutedEventHandler(llamar);
                   btnClick3.Click += new RoutedEventHandler(siguientePaso);
               }
               Panel.Children.Remove(txtbox);
               Panel.Children.Remove(list3);
               Panel.Children.Remove(btnClick3);
               Panel.Children.Add(list3);
               Panel.Children.Add(btnClick3);

           }
           else
           {

               if (root4.Fields[preguntas].field_type.Equals("3"))
               {

                   texto1.Text = "" + root4.Fields[preguntas].caption;
                   preguntas = preguntas + 1;

                   if (preguntas < root4.Fields.Count)
                   {
                       btnClick3.Click -= new RoutedEventHandler(siguientePaso);
                       btnClick3.Click -= new RoutedEventHandler(llamar);
                       btnClick3.Click += new RoutedEventHandler(llamar);
                   }
                   else
                   {
                       btnClick3.Click -= new RoutedEventHandler(siguientePaso);
                       btnClick3.Click -= new RoutedEventHandler(llamar);
                       btnClick3.Click += new RoutedEventHandler(siguientePaso);
                   }
                   Panel.Children.Remove(txtbox);
                   Panel.Children.Remove(list3);
                   Panel.Children.Remove(btnClick3);
                   // Panel.Children.Add(list3);
                   Panel.Children.Add(btnClick3);
               }
               else 
               {
                   if (root4.Fields[preguntas].field_type.Equals("2"))
                   {
                       texto1.Text = "" + root4.Fields[preguntas].caption;
                       preguntas = preguntas + 1;

                       if (preguntas < root4.Fields.Count)
                       {
                           btnClick3.Click -= new RoutedEventHandler(siguientePaso);
                           btnClick3.Click -= new RoutedEventHandler(llamar);
                           btnClick3.Click += new RoutedEventHandler(llamar);
                       }
                       else
                       {
                           btnClick3.Click -= new RoutedEventHandler(siguientePaso);
                           btnClick3.Click -= new RoutedEventHandler(llamar);
                           btnClick3.Click += new RoutedEventHandler(siguientePaso);
                       }
                       
                       txtbox.Text = " ";
                       txtbox.Width = 212;
                       txtbox.Height = 75;
                       Panel.Children.Remove(txtbox);
                       Panel.Children.Remove(list3);
                       Panel.Children.Remove(btnClick3);
                       // Panel.Children.Add(list3);
                       Panel.Children.Add(txtbox);
                       Panel.Children.Add(btnClick3);
                   }
               }
           }
         }
            catch (Exception ex)
           {
                MessageBox.Show(ex.ToString());
               //MessageBox.Show("Este subproceso no contiene instrucciones");
           }
       }

       public void siguientePaso(object sender, RoutedEventArgs e)
       {
           
            respuesta.Add("" + list3.SelectedItem);
            preguntas = 0;
            if (!txtbox.Text.Equals(""))
            {
                 respuesta.Add(txtbox.Text.Trim());
                txtbox.Text = "";
                numerovalidado = 1;
            }
            
            
            string resultadoA = "", resultadoB = "", siguienteStep="";
           //como son varios branch entonces string sumando cada uno y quede concadenado y concadeno de respuesta, despues del for pregunto si son iguales, i lo son salta a donde el dice,  preguntar si es -1 hay acaba
            for (int i = 0; i < respuesta.Count;i++ )
            {
                resultadoA = resultadoA + respuesta[i];
            }
           
            Contenido root4 = JsonConvert.DeserializeObject<Contenido>(root3[siguiente].content);
            string aaaaa = "",bbb="";
           
            for (branch=0; branch < root4.Decisions.Count;branch++ )
            {
                
                for (int j = 0; j < root4.Decisions[branch].branch.Count; j++)
                {
                    
                    resultadoB = resultadoB + root4.Decisions[branch].branch[j].value;
                    bbb = root4.Decisions[branch].branch[j].comparison_type; 
                    
                }
                
                if(resultadoA.Equals(resultadoB))
                {
                    siguienteStep = root4.Decisions[branch].go_to_step;
                    branch = 999;
                    aaaaa = resultadoB;
                }
                if (numerovalidado == 1 && bbb.Equals("<"))
                {
                    
                    if (Convert.ToInt32(resultadoA) < Convert.ToInt32(resultadoB))
                    {
                        siguienteStep = "7";
                        branch = 999;
                        aaaaa = resultadoB;
                    }
                 else {
                        if (Convert.ToInt32(resultadoA)> Convert.ToInt32(resultadoB))
                        {
                            siguienteStep = root4.Decisions[branch].go_to_step;
                            branch = 999;
                            aaaaa = resultadoB;
                        }
                    }
                }
                else {
                    if (numerovalidado == 1 && bbb.Equals(">"))
                    {
                        if (Convert.ToInt32(resultadoA) < Convert.ToInt32(resultadoB))
                        {
                            siguienteStep = "7";
                            branch = 999;
                            aaaaa = resultadoB;
                        }
                        else {
                            if (Convert.ToInt32(resultadoA) > Convert.ToInt32(resultadoB))
                             {
                                siguienteStep = root4.Decisions[branch].go_to_step;
                                branch = 999;
                                aaaaa = resultadoB;
                            }
                        }

                    }
                }
                resultadoB="";
            }
            
            if (siguienteStep.Equals("-1"))
            {
                MessageBox.Show("termino");
                /*Panel.Children.Remove(list3);
                Panel.Children.Remove(btnClick3);
                texto1.Text = "Escoge tu categoria";
                list.Visibility = Visibility.Visible;
                btnClick.Visibility = Visibility.Visible;*/
            }
            else
            {
                for (int k = 0; k < root3.Count;k++ )
                {
                   // MessageBox.Show(siguienteStep + " y " + root3[k].step_id);
                    
                    if(siguienteStep.Equals(""+root3[k].step_id))
                    {
                        siguiente = k; 
                        k = 999;
                    }
                }
                //Panel.Children.Remove(list3);mirar bn aqui por si acaso
                list3.Items.Clear();
                branch = 0;
                respuesta.Clear();
               /* btnClick3.Click -= new RoutedEventHandler(siguientePaso);
                btnClick3.Click += new RoutedEventHandler(llamar);*/
                traerJsontodos();
                txtbox.Text="";
                numerovalidado = 0;
                //preguntas
            }
            txtbox.Text="";
            branch = 0;
            numerovalidado = 0;
           // Panel.Children.Remove(list3);
           // MessageBox.Show("Si entro "+siguienteStep+" "+preguntas);
            
        }
    }
}