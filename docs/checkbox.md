# Checkbox
Leonardo Styled Checkbox 

# Regular
![Regular Style](https://github.com/q2g/leonardo-wpf/blob/master/docs/pictures/checkbox_regular.png)
#### Usage
Import the control-Namespace in your Containig Control:
````
xmlns:controls="clr-namespace:leonardo.Controls;assembly=leonardo-wpf"
````

```
<controls:LuiCheckbox  Text="Label" />
<controls:LuiCheckbox  Text="Label" IsChecked="True"/>
<controls:LuiCheckbox  Text="Label" IsEnabled="False"/>
<controls:LuiCheckbox  Text="Label" IsEnabled="False" IsChecked="True" />
```
# Inverted
Activate Inverted-Look on all leonardo-wpf Controls via the Inverted Attached Property

![Inverted Style](https://github.com/q2g/leonardo-wpf/blob/master/docs/pictures/checkbox_inverted.png)
#### Usage
Import the Inverted Attached Property to activate the Inverted-Look on Lui-Controls.
Add the Following Namespace to the Control containing the LuiCheckbox:
```
xmlns:attached="clr-namespace:leonardo.AttachedProperties;assembly=leonardo-wpf"
```
Now you can use the *ThemeProperties.Inverted* Attached Property.
```
<controls:LuiCheckbox attached:ThemeProperties.Inverted="True"  Text="Label" />
<controls:LuiCheckbox attached:ThemeProperties.Inverted="True"  Text="Label" IsChecked="True"/>
<controls:LuiCheckbox attached:ThemeProperties.Inverted="True"  Text="Label" IsEnabled="False"/>
<controls:LuiCheckbox attached:ThemeProperties.Inverted="True"  Text="Label" IsEnabled="False" IsChecked="True" />
```

