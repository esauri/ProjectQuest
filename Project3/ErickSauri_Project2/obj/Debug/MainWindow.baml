   M S B A M L   `   `   `  ����  ErickSauri_Project2    Sauri_Project3.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  window��5   	    � Title$ Dungeon��5   	   $	��555��6   $	��635��6&   ���	#FFF0F0F0.��5      � -   5         �Name$ 	outerGrid��5      $��0,0,0,0q�6   .+�5   
   � -   5        $ bgGrid��5      $��0,0,0,0q�6   62   � 5   
   -   5        $ myGrid��5      .+�5      �� -   5         ��Name$ 	goldCount��5      $
��Left=�6+   $��
530,10,0,0q�6F   $
��Wrap=�6Z   $��Gold: 0��6n   $	��Top=�6}   �� 5	      -   5         ��Name$ 
loadButton��5	      $��Load Dungeon��6)   $
��Left=�6@   $��530,160,0,0q�6[   $	��Top=�6p   $��75��6�   $��11(�6�    J� RenderTransformOrigin$ 
0.48,0.368&�6�    � ToolTip$4 .Loads a pre-existing dungeon from a text file.��6�   �� 5
      -   5        $ 
saveButton��5
      $��Save Dungeon��6)   $
��Left=�6@   $��530,110,0,0q�6[   $	��Top=�6p   $��75��6�   $��11(�6�   $ 	0.5,0.368&�6�   $6 0Saves the current dungeon layout as a text file.��6�   �� 5      -   5        $ resetButton��5      $��Generate��6*   $
��Left=�6=   $��
530,60,0,0q�6X   $	��Top=�6l   $��75��6�   $��11(�6�   $ 
0.48,0.368&�6�   $6 0Generates a new dungeon randomly spawning walls.��6�   �� 5      -	   5        $ clearButton��5      $��Clear��6*   $
��Left=�6:   $��530,210,0,0q�6U   $	��Top=�6j   $��75��6�   $��11(�6�   $ 
0.48,0.368&�6�   $: 4Remove all obstacles from the board and resets game.��6�   5      5      5      