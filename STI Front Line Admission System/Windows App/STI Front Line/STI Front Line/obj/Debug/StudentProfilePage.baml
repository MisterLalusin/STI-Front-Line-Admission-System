   M S B A M L   `   `   `  ����I  ESTI Front Line, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:STI_Front_LineSTI_Front_Line  5      '    !STI_Front_Line.StudentProfilePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:STI_Front_Line     5        N� Title$  StudentProfilePage��5	       N� 
Background
 �����.��5      �� 
�������.+�5   
   � $��5,5,5,5q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��20 �6#   �� 5      $	��200 �6#   �� 5      $��60 �6#   .+�5      �� $��Right=�6   $��0��65    �� Orientation$ 
Horizontal=�6E   .+�5      �� -   5         ��Name$ smlrCHCKBXNM��5      $��10,0,0,0q�61   $��Center=�6C   .��6^   Similar Search6n   �� 5      $��10,0,0,0q�6   $��1��6,   
�������$��1��6I   6[   �� 5      -   5        $ crrntschlyrCHCKBXNM��5      $��10,0,0,0q�68   $��Center=�6J   .��6e   Current School Year6z   �� 5      $��10,0,0,0q�6   $��1��6,   
�������$��1��6I   6[   �� 5      -   5        $ 
mlCHCKBXNM��5      $��10,0,0,0q�6L   $��Center=�6^   .��6y   Male6   �� 5      -   5        $ fmlCHCKBXNM��5      $��10,0,0,0q�6N   $��Center=�6`   .��6{   Female6�   5      �� 5      $��1��6   
�������$��1��62   6D   �� 5      -   5         ��Name$ srchTXTBXNM��5   &   $��2��6   $��0,0,10,0q�5      $��20��5      .��5   <   5       �� 5!      -   5        $��	srchBTNNM��5!      $��0,0,10,0q�5"      $��Search��5#      $��3��5$      $��20��5%      $��13(�5&      5'      5(      &   System.Windows.Controls.DataGrid  5)   
   -   5        $��dtgrdNM��5)      $��0,1,0,0q�5*      
�������$	��510��5,      $	��703��5-         AutoGenerateColumns .  $
��Left=�5/         CanUserResizeRows .     CanUserAddRows .  ��50      �� *DTV+	   Columns	 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn
   Header$
  ��6%      
IsReadOnly .    MinWidth$ 50Q�6i      MaxWidth$ 0Q�6w   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6/   ��  �� Path$ TRANSACTION_ID�6w     56      $
 Student Name��6%    . $	 260Q�6s   $	 260Q�6�    6;   �� $ STUDENT_NAME�6�     57      $
 Course��6%    . $	 260Q�6g   $	 260Q�6v    65   �� $ COURSE�6v     58      $
 
Year/Grade��6%    . $ 80Q�6r   $ 80Q�6�    69   �� $ YEAR_OR_GRADE�6�     59      $
 School Year��6%    . $ 80Q�6q   $ 80Q�6    6:   �� $ SCHOOL_YEAR�6   5;      5<      5=      