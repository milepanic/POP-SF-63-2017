   M S B A M L   `   `   `  ����M  IPOP-SF-63-2017-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:POP_SF_63_2017_GUI.GUIPOP_SF_63_2017_GUI.GUI  5   	   0    *POP_SF_63_2017_GUI.GUI.DodatnaUslugaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:POP_SF_63_2017_GUI.GUI     5   	     � Title$  DodatnaUslugaWindow��5   	   $	��300��6%   $	��300��62   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��31* �6   �� 5      $	��40* �6   �� 5      $	��52* �6   �� 5      $	��86* �6   �� 5      $	��40* �6   �� 5      $	��21* �6    � ColumnDefinitions 5   
   �� 5      $	��21* �6   �� 5      $	��52* �6   .+�5   
   �� -   5         ��Name$ lbNaziv��5      $��Naziv��6!   $
��Left=�5      $��1��6+   $	��Top=�5      $��84��6(   $��40��5      �� 5   
   -   5         ��Name$ tbNaziv��5      $��1��6#   $
��Left=�5      $��40��6-   $��1��5       �� TextWrapping$
 Wrap=�6   $	��Top=�5      $	��208��6*   ��5      ��  �� Path$ Naziv��� 5   
   -   5        $ lbCena��5      $
��Cena��6    $
��Left=�5       $��2��6+   $	��Top=�5!      $��84��6(   $��40��5"      $��0,18,0,0q�6   $��2��6.   �� 5#   
   -   5        $ tbCena��5#      $��1��6"   $
��Left=�5$      $��40��6-   $��2��5%      $
 Wrap=�6   $	��Top=�5'      $	��208��6*   $��0,18,0,0q�66   $��2��6H   ��5&      �� $
 Cena�5'   H   �� 5(   
   -   5         ��Name$ 	btnIzadji��5(      $��Izadji��6$   $��1��5)      $
��Left=�6!   $��	101,0,0,0q�5*      $��4��6$   $	��Top=�5+      $	��107��6)   $��40��5,      6   �� 5-   
   -   5        $ 
btnSacuvaj��5-      $��Sacuvaj��6%   $��1��5.      $
��Left=�6!   $��4��5/      $	��Top=�6   $��96��50       J� RenderTransformOrigin$ -0.254,-0.007&�6   $��40��51      6   52      53      