   M S B A M L   `   `   `  ����  ErickSauri_Project2!    Sauri_Project3.BattleWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  BattleWindow��5   	   $	��300��6   $	��300��6+    � 
ResizeMode$ NoResize=�6P    � WindowStyle$
 None=�6f   .��5      � .+�5   
   �� -   5         ��Name$ heroHP��5      $
��Left=�6$   $��	16,44,0,0q�6?   $
��Wrap=�6R   $��	Health: 3��6f   $	��Top=�6w    J� RenderTransformOrigin$ 0.462,0.543&�6�   �� 5   
   -   5        $ 	combatLog��5      $
��Left=�6'   $��171,167,0,0q�6B   $
��Wrap=�6W   $	��Top=�6k   $	��100��6�   $	��100��6�   �� 5   
   -   5        $ 	enemyName��5      $
��Left=�6'   $��
171,11,0,0q�6B   $
��Wrap=�6V   $	��Top=�6j   $	��119��6�   $��49��6�   $)��#Rekkul, Champion of the Blood Guard��6�   �� 5	   
   -   5        $ heroName��5	      $
��Left=�6&   $��	16,11,0,0q�6A   $
��Wrap=�6T   $	��Top=�6h   $	��100��6�   $��21��6�   $	��You��6�   �� 5
   
   -   5         ��Name$ enemypic��5
      $
��Left=�6"   $	��100��6=   $��
171,65,0,0q�6J   $	��Top=�6^   $	��100��6v    	  champ#���   6�   �� 5   
   -   5        $ heropic��5      $
��Left=�6!   $	��100��6<   $��	16,65,0,0q�6I   $	��Top=�6\   $	��100��6t   $��Projectpics/hero.png��6�   �� 5   
   -   5        $ enemyHP��5      $
��Left=�6%   $��
171,44,0,0q�6@   $
��Wrap=�6T   $��	Health: 1��6h   $	��Top=�6y   $ 0.462,0.543&�6�   �� 5   
   -	   5         ��Name$ attackButton1��5      $��Heroic Strike��6(   $
��Left=�6@   $��
16,165,0,0q�6[   $	��Top=�6o   $��75��6�   $	��0.1q�6�    J� Opacity$	 0.7Q�6�   
�������$��Euphemia)�6�    � ToolTip$( "Attack the enemy with your weapon.��6�   �� 5   
   -
   5        $ attackButton2��5      $��Electrocute��6(   $
��Left=�6>   $��
16,190,0,0q�6Y   $	��Top=�6m   $��75��6�   $	��0.1q�6�   $	 0.7Q�6�   
�������$/ )Electrocute the enemy with your gauntlet.��6�   $y�Hidden=�6  �� 5   
   -   5        $ attackButton3��5      $��Flame Blast��6(   $
��Left=�6>   $��
16,215,0,0q�6Y   $	��Top=�6m   $��75��6�   $	��0.1q�6�   $	 0.7Q�6�   
�������$A ;Cast a powerful Fire spell that will incinerate your enemy.��6�   $y�Hidden=�6)  �� 5   
   -   5        $ attackButton4��5      $
��Heal��6(   $
��Left=�67   $��
16,240,0,0q�6R   $	��Top=�6f   $��75��6~   $	��0.1q�6�   $	 0.7Q�6�   
�������$4 .Pray to the gods that they will replenish you.��6�   $y�Hidden=�6  5      5      