   M S B A M L   `   `   `  ����F  Booplab3GMAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ooplab3GMAPooplab3GMAP  5   	   c _GMap.NET.WindowsPresentation, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b85b9027b614afefqPclr-namespace:GMap.NET.WindowsPresentation;assembly=GMap.NET.WindowsPresentationGMap.NET.WindowsPresentation 5   	       ooplab3GMAP.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ooplab3GMAP     5   	   pWindowsPresentationPclr-namespace:GMap.NET.WindowsPresentation;assembly=GMap.NET.WindowsPresentation     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      � .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $��65��6T   $��	10,10,0,0q�6`   $	��Top=�6s   $	��148��6�   	� 5   
   -   5         	�Name$ RBcreate��5      $��create��6(   $
��Left=�69   $��	19,36,0,0q�6T   $	��Top=�6g   6   	� 5   
   -   5        $ RBsearchforthenearest��5      $��search for the nearest��65   $
��Left=�6V   $��14��6q   $��	19,56,0,0q�6}   $	��Top=�6�   $	��139��6�   6�   �� 5   
   $��cursor mode��6   $
��Left=�6&   $��	10,10,0,0q�6A   $	��Top=�6T   �� 5   
   -   5         ��Name$
 Badd��5      
���   �$��1q�63   $
��Left=�6G   $	��127��6b   $��	10,80,0,0q�6o   $	��Top=�6�   $	��228��6�   �� 5   
   -   5         ��Name$
 Ladd��5      $	��add��6   $
��Left=�6,   $��	10,80,0,0q�6G   $	��Top=�6Z   �� 5   
   -   5         ��Name$ 	CBobjects��5      $
��Left=�6&   $��
19,106,0,0q�6A   $	��Top=�6U   $	��120��6m   6y   �� 5   
   -   5         ��Name$ TBname��5      $
��Left=�6"   $��22��6=   $��
19,128,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��120��6�   �� 5   
   -   5         ��Name$ Baddname��5      $��ok��6#   $
��Left=�60   $��
19,155,0,0q�6K   $	��Top=�6_   $��75��6w   6�   �� 5   
   -   5        $ Breset��5      $��reset points��6!   $
��Left=�68   $��
19,180,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -	   5        $ Bsearch��5      
���   �$��1q�66   $
��Left=�6J   $	��197��6e   $��
10,212,0,0q�6r   $	��Top=�6�   $	��228��6�   �� 5   
   -
   5        $ Lsearch��5      $��search��6!   $
��Left=�62   $��
10,207,0,0q�6M   $	��Top=�6a   �� 5   
   -   5        $ TBsearch��5      $
��Left=�6$   $��23��6?   $��
19,238,0,0q�6K   $
 Wrap=�6_   $��found��6s   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ Bfound��5      $��ok��6!   $
��Left=�6.   $��
20,266,0,0q�6I   $	��Top=�6]   $��74��6u   6�   �� 5   
   -   5        $ Lresult��5      $��result of search:��6!   $
��Left=�6=   $��
10,309,0,0q�6X   $	��Top=�6l   �� 5   
   -   5         ��Name$ LBresultofsearch��5      $
��Left=�6,   $��85��6G   $��106,309,0,0q�6S   $	��Top=�6h   $	��118��6�   6�   � 5   
   -   5        	 �Name$
	 gmap��5      $
��Left=�6   $	��350��68   $��292,10,10,10q�6E   $��Bottom=�6[   $	��490��6v   .+�5      .  (GMap.NET.WindowsPresentation.GMapControl  -   5        $	��Map��5   .   6�   5      �� 5   
   -   5        $ Lx��5      $��0��6   $
��Left=�6(   $��
168,33,0,0q�6C   $	��Top=�6W   �� 5    
   -   5        $ Ly��5       $��0��6   $
��Left=�6(   $��
168,52,0,0q�6C   $	��Top=�6W   �� 5!   
   $��coordinates:��6   $
��Left=�6'   $��
163,10,0,0q�6B   $	��Top=�6V   �� 5"   
   -   5        $ Bcallcar��5"      $
��call��6#   $
��Left=�62   $��
292,10,0,0q�6M   $	��Top=�6a   $��84��6y   $��31��6�   
 J� RenderTransformOrigin$
 -4.576,1.177&�6�   6�   � 5#   
   -   5         �Name$ progressLine��5#      $
��Left=�6,   $��31��6G   $��
383,10,0,0q�6S   $	��Top=�6g   $	��399��6   $
 0.5,0.5&�6�   z�5$      V� 5%      .~�5&      �� �� 5'      �� 5(       �� Angle$ 0Q�6&   T� 5)      5*      5,      5.      50      