# LuiRadiobutton
Leonardo Styled Radio Buttons 

# Regular
![Regular Style](https://github.com/q2g/leonardo-wpf/blob/master/docs/pictures/radiobutton_regular.png)
#### Usage
Import the control-Namespace in your Containig Control:
````
xmlns:controls="clr-namespace:leonardo.Controls;assembly=leonardo-wpf"
````

```
<controls:LuiRadiobutton  Text="Label" />
<controls:LuiRadiobutton  Text="Label" IsChecked="True"/>
<controls:LuiRadiobutton  Text="Label" IsEnabled="False"/>
<controls:LuiRadiobutton  Text="Label" IsEnabled="False" IsChecked="True" />
```
# Inverted
Activate Inverted-Look on all leonardo-wpf Controls via the Inverted Attached Property

![Inverted Style](https://github.com/q2g/leonardo-wpf/blob/master/docs/pictures/radiobutton_inverted.png)
#### Usage
Import the Inverted Attached Property to activate the Inverted-Look on Lui-Controls.
Add the Following Namespace to the Control containing the LuiRadiobutton:
```
xmlns:attached="clr-namespace:leonardo.AttachedProperties;assembly=leonardo-wpf"
```
Now you can use the *ThemeProperties.Inverted* Attached Property.
```
<controls:LuiRadiobutton attached:ThemeProperties.Inverted="True"  Text="Label" />
<controls:LuiRadiobutton attached:ThemeProperties.Inverted="True"  Text="Label" IsChecked="True"/>
<controls:LuiRadiobutton attached:ThemeProperties.Inverted="True"  Text="Label" IsEnabled="False"/>
<controls:LuiRadiobutton attached:ThemeProperties.Inverted="True"  Text="Label" IsEnabled="False" IsChecked="True" />
```

