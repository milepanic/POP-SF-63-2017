   M S B A M L   `   `   `  ����M  IPOP-SF-63-2017-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:POP_SF_63_2017_GUI.GUIPOP_SF_63_2017_GUI.GUI  5   	   .    (POP_SF_63_2017_GUI.GUI.ProdajaCRUDWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:POP_SF_63_2017_GUI.GUI     5   	     � Title$  ProdajaCRUDWindow��5   	   $��540.376��6#   $��913.929��64   .��5	      � $��	0,0,15,39q�6    � RowDefinitions 5
   
   �� 5      $	��21* �6   �� 5      $
��131* �6   �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ header��5      $��Prodaja��6    $
��Left=�5      $	��Top=�6+   $��10,10,-206,0q�6C   $��35��5      $	��588��6   $��2��6(   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�5      $	��396��6-   $��10,0,0,0q�5      $��1��6$   $	��Top=�5      $	��871��6*      
IsReadOnly .    CanUserAddRows .   �� SelectedItem 5      ��  �� Path$ IzabranaProdaja�5      �� 5   
   -   5         ��Name$ btnIzlaz��5      $
��Left=�6#   $	��Top=�5      $��89��6)   $��792,0,0,-25q�5      $��2��6&   $��25��5      .��64   Izlaz5      �� 5    
   -   5        $ btnDodaj��5       $��Dodaj��6#   $
��Left=�5!      $	��Top=�6,   $��75��5"      $��
10,0,0,-25q�5#      $��2��6%   $��25��5$      �� 5%   
   -   5        $ 	btnObrisi��5%      $��Obrisi��6$   $
��Left=�5&      $	��Top=�6,   $��75��5'      $��170,0,0,-25q�5(      $��2��6&   $��25��5)      	 J� RenderTransformOrigin$	 
0.747,0.96&�6   �� 5*   
   -   5        $ btnRacun��5*      $��Prikazi racun��6#   $
��Left=�5+      $	��Top=�6(   $��75��5,      $��
90,0,0,-25q�5-      $��2��6!   $��25��5.      $	 
0.747,0.96&�6   5/      50      