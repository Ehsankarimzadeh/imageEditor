   M S B A M L   `   `   `  ����K  GImagesProcessing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ImagesProcessing.EditImagesProcessing.Edit  5   	   $    ImagesProcessing.Edit.EditPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ImagesProcessing.Edit     5   	     � Title$  	Edit Page��5   	   
��� ���$	��610��6/   $	��800��6<   .��5	      � 
���   �$��20q�6   .+�5
   
   �� -   5         ��Name$ imageBox��5
      $��Stretch=�6"   $	��350��6@   $��10,10,10,10q�6M   $	��Top=�6b   $	��500��6z   �� 5   
   -   5         ��Name$ 	briSlider��5      $
��Left=�6$   $��130,390,0,0q�6?   $	��Top=�6T   $	��220��6l    � Maximum$ 2Q�6x    � Value$ 1Q�6�   �� 5   
   -   5        $ 	conSlider��5      $
��Left=�6$   $��130,440,0,0q�6?   $	��Top=�6T   $	��220��6l   $ 2Q�6x   $ 1Q�6�   �� 5   
   -   5        $ sharpSlider��5      $
��Left=�6&   $��17��6A   $��130,490,0,0q�6M   $	��Top=�6b   $	��220��6z   $ 3Q�6�   $ 1Q�6�   �� 5   
   $��34��6   $��35,382,676,0q�6   $	��Top=�62   $��/Resources/brightness.png��6J   �� 5   
   $��34��6   $��35,432,676,0q�6   $	��Top=�62   $��/Resources/contrast.png��6J   �� 5   
   $��35��6   $��35,481,676,0q�6   $	��Top=�62   $ ��/Resources/sharpenning.png��6J   �� 5   
   -   5         ��Name$ createImageBtn��5      $��Create Image��6)   $��27(�6@   $��Freestyle Script)�6N   $
��Left=�6l   $��485,406,0,0q�6�   $	��Top=�6�   $��71��6�   $	��105��6�   
��� ���
�������6�   �� 5   
   -   5        $ saveBtn��5      $
��Save��6"   $
��Left=�61   $��610,454,0,0q�6L   $	��Top=�6a   $	��111��6y   $��63��6�   
��� � �
�������$��40(�6�   $��Freestyle Script)�6�   6�   �� 5   
   -   5        $ 	CancelBtn��5      $��Cancel��6$   $
��Left=�65   $��610,380,0,0q�6P   $	��Top=�6e   $	��111��6}   $��63��6�   
���  ��
�������$��40(�6�   $��Freestyle Script)�6�   �� 5   
   -   5        $ mainImageBox��5      $��Stretch=�6&   $	��350��6D   $��10,10,10,10q�6Q   $	��Top=�6f   $	��500��6~   $y�	Collapsed=�6�   5      5      