   M S B A M L   `   `   `  ����?  ;tesy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:tesytesy  5      Q MZedGraph, Version=5.1.7.430, Culture=neutral, PublicKeyToken=02a83cbd123fcd605(clr-namespace:ZedGraph;assembly=ZedGraphZedGraph 5      R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0>.clr-namespace:OxyPlot.Wpf;assembly=OxyPlot.WpfOxyPlot.Wpf 5          tesy.CustomUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:tesy     5      8zed(clr-namespace:ZedGraph;assembly=ZedGraph     5      >oxy.clr-namespace:OxyPlot.Wpf;assembly=OxyPlot.Wpf     5      .��5      � .+�5   
     OxyPlot.Wpf.Plot  -   5           Name$  oxyPlot2��5       $��0��6      Title$  ��62   $��30q�6;   
������    PlotAreaBorderThickness$ 10,10,10,10q�6`   5        OxyPlot.Wpf.PlotView  5   
   -   5          Name$ plotModelUIElement��5   Q   $	��500��68   $	��400��6D   $��Right=�6m   $��Center=�6�   $��0,0,10,0q�6�      Model 6   �� *plotViewModel+5      �� 5   
   -   5        $��
filesLabel��5      $��files��6&   $��12(�63   $��5, 30, 0, 0q�6B   $	��Top=�5   
   $
��Left=�6$   6A   �� 5   
   -   5        $��	filesName��5   
   $��23��5      $��40, 30, 0, 0q�5      $	��Top=�5   
   $
��Left=�6$   $	��200��6?   ��5      �� *
filesPaths+5   ?   �� 5   
   -   5        $��nLabel��5      $��N��6"   $��12(�6+   $��5, 60, 0, 0q�6:   $	��Top=�5   
   $
��Left=�6$   6A   �� 5   
   -   5        $��n��5   
   $��23��5      $��40, 60, 0, 0q�5      $	��Top=�5   
   $
��Left=�6$   $	��200��6?   ��5      �� *numberOfRows+5   ?   �� 5!   
   -   5        $��mLabel��5!      $��M��6"   $��12(�6+   $��5, 90, 0, 0q�6:   $	��Top=�5"   
   $
��Left=�6$   6A   �� 5$   
   -   5        $��m��5%   
   $��23��5$      $��40, 90, 0, 0q�5'      $	��Top=�5(   
   $
��Left=�6$   $	��200��6?   ��5&      �� *numberOfColumns+5(   ?   �� 5+   
   -	   5        $��	xResLabel��5+      $
��xRes��6%   $��12(�61   $��5, 120, 0, 0q�6@   $	��Top=�5,   
   $
��Left=�6$   6A   �� 5-   
   -
   5        $
��xRes��5.   
   $��23��5-      $��40, 120, 0, 0q�50      $	��Top=�51   
   $
��Left=�6$   $	��200��6?   ��5/      �� *xRes+51   ?   �� 54   
   -   5        $��	yResLabel��54      $
��yRes��6%   $��12(�61   $��5, 150, 0, 0q�6@   $	��Top=�55   
   $
��Left=�6$   6A   �� 56   
   -   5        $
��yRes��57   
   $��23��56      $��40, 150, 0, 0q�59      $	��Top=�5:   
   $
��Left=�6$   $	��200��6?   ��58      �� *yRes+5:   ?   �� 5=   
   -   5        $��
xAxisTitle��5=      $��xLabel��6&   $��12(�64   $��5, 180, 0, 0q�6C   $	��Top=�5>   
   $
��Left=�6$   6A   �� 5?   
   -   5        $��xLabel��5@   
   $��23��5?      $��40, 180, 0, 0q�5B      $	��Top=�5C   
   $
��Left=�6$   $	��200��6?   ��5A      �� *xLabel+5C   ?   �� 5E   
   -   5        $��
yAxisLabel��5E      $��yLabel��6&   $��12(�64   $��5, 210, 0, 0q�6C   $	��Top=�5F   
   $
��Left=�6$   6A   �� 5G   
   -   5        $��yLabel��5H   
   $��23��5G      $��
40,210,0,0q�5J      $	��Top=�5K   
   $
��Left=�6$   $	��200��6?   ��5I      �� *yLabel+5K   ?   �� 5M   
   -   5        $��button��5O   !   $
��Draw��5M      $��23��5N   
   $
��Left=�6   $��120,240,0,0q�5O   
   $	��Top=�5P   
   ��6$   �� *drawChartCommand+5Q      5R      