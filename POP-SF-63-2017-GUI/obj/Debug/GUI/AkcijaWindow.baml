   M S B A M L   `   `   `  ����M  IPOP-SF-63-2017-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:POP_SF_63_2017_GUI.GUIPOP_SF_63_2017_GUI.GUI  5   	   )    #POP_SF_63_2017_GUI.GUI.AkcijaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:POP_SF_63_2017_GUI.GUI     5   	     � Title$  AkcijaWindow��5   	   $��365.9��6   $��362.134��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��134* �6   �� 5      .+�5   
   � $
��Left=�6   $	��224��6*   $��10,10,-31,0q�67   $	��Top=�6L   $	��313��6d   .+�5      �� -   5         ��Name$ lbDatumPocetka��5      $��Datum pocetka��6,   $
��Left=�5      $	��Top=�6/   $��	10,26,0,0q�5      $	��120��6'   �� 5      -   5        $ lbDatumZavrsetka��5      $��Datum zavrsetka��6.   $
��Left=�5      $	��Top=�6/   $��	10,57,0,0q�5      $	��120��6'   �� 5      -   5        $ lbPopust��5      $��Popust��6&   $
��Left=�5      $	��Top=�6/   $��	10,88,0,0q�5      $	��120��6'   �� 5      -   5         ��Name$ tbPopust��5      $
��Left=�6(   $��26��5      $��
135,88,0,0q�6"    �� TextWrapping$
 Wrap=�5      $	��Top=�6*   $	��120��5      ��6"   ��  �� Path$ Popust�(  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpPocetakAkcije��5      $
��Left=�62   $	��Top=�5      $��
135,26,0,0q�61   $	��120��5         FirstDayOfWeek$ Monday=�6%      SelectedDate 5      �� $ DatumPocetka�  5       -   5        $ dpZavrsetakAkcije��5       $
��Left=�64   $��
135,58,0,0q�5!      $	��Top=�6-   $	��120��5"      $ Monday=�6%    5#      �� $ DatumZavrsetka�5$      � 5%   
   $
��Left=�6   $��68��6*   $��10,239,-31,-37q�5&      $	��Top=�6'   $	��313��5'      $��2��6   .+�5(      �� -   5        	 ��Name$	 
btnSacuvaj��5(      $��Sacuvaj��6)   $
��Left=�5)      $��	10,34,0,0q�5*      $	��Top=�6(   $��85��5+      $��27��6    6,   �� 5,      -   5        $	 btnIzlaz��5,      $��Izlaz��6'   $
��Left=�5-      $��
218,34,0,0q�60   $	��Top=�5.      $��85��6-   $��27��5/      6!   50      51      52      