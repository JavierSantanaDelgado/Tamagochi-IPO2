   M S B A M L   `   `   `  ����D  @Tamagochi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Tamagochi	Tamagochi  5   	   !    Tamagochi.VentanaBienvenida   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Tamagochi     5   	   $	��300��5      $	��600��6'     � WindowStartupLocation$  CenterScreen=�63    � Icon$A ;https://www.centrosuniversitarios.com/uploads/uclm_logo.jpg��6X   $��Disabled=�6�    � WindowStyle$
 None=�6�    � 
ResizeMode$ NoResize=�6�    � TaskbarItemInfo 5      *  $System.Windows.Shell.TaskbarItemInfo  5	   
   ��5      �� 5   
    �� ImageSource$` Zhttps://www.solofondos.com/wp-content/uploads/2016/05/1213c07afd537fa99a0173975c9ab758.jpg��6    j� Stretch$ UniformToFill=�6~    j� TileMode$ FlipX=�6�   .��5      �  � RowDefinitions 5   
   �� 5      $	��31* �6   �� 5      $	��29* �6   	 � ColumnDefinitions	 5   
   �� 5      $
��287* �6   �� 5      $
��313* �6   ��5   
   �� 5      $* $1213c07afd537fa99a0173975c9ab758.jpg��6   $
 None=�6L   .+�5   
   �� -   5        
 ��Name$
 lblTituloProyecto��5      $��IPO 2 - Tamagotchi��6+   $
��Left=�6H   $��
24.8,0,0,0q�6c   $	��Top=�6w   $	��288��6�   $��30(�6�   $
��Bold"�6�   $��SimSun)�6�   
�������$��1��6�   $��44��6�   �� 5   
   -   5        $
 lblNombreTama��5      $��Nombre del 
Tamagotchi:��6'   $
��Left=�6M   $��94��6h   $��10,23.6,0,0q�6t   $	��Top=�6�   $	��281��6�   $��24(�6�   
�������$
��Bold"�6�   $��SimSun)�6�   $��1��6�   $��2��6  �� 5   
   -   5         ��Name$ tbNombreTama��5      $
��Left=�6(   $��50��6C   $��10,84.6,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��190��6�   
���   �$��21(�6�   $
��Bold"�6�   
�������$��Center=�6�   $��Center=�6  $��SimSun)�6?  $��1��6h   � ToolTip$&  Escriba el nombre del Tamagotchi��6u  ��6�   Z� 6u  �� 5   
   -   5         ��Name$ 
btnEmpezar��5      $��Empezar��6%   $
��Left=�67   $��129.6,88.6,0,10q�6R   $��173.4��6k   
�������$��24(�6�   $��SimSun)�6�   ���	#FF804000$��1��6�   $��1��6�   �� 5   
   -   5        $
��Left=�5      $
��20.8��6+   $��200,114.2,0,0q�69   $��1��6P   $	��Top=�6]   $
��21.6��6u   $.��(240-2407216_cube-iconos-de-ayuda-png.png��6�   $ Botón de ayuda��6�   5       5!      