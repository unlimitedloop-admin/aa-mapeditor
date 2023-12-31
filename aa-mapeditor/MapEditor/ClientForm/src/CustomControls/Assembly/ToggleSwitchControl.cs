/**************************************************************/
//
//
//      Copyright (c) 2023 UNLIMITED LOOP ROOT-ONE
//
//
//      This software(and source code) is completely Unlicense.
//      see "LICENSE".
//
//
/**************************************************************/
//
//
//      Arthentic Action Map Editor (Csharp Edition)
//
//      File name       : ToggleSwitchControl.cs
//
//      Author          : u7
//
//      Last update     : 2023/12/09
//
//      File version    : 2
//
//
/**************************************************************/

/* using namespace */
using static Properties.Resources;



/* sources */
namespace ClientForm.src.CustomControls
{
    /// <summary>
    ///  Toggle switch control with general purpose logic values
    /// </summary>
    public partial class ToggleSwitchControl : UserControl
    {
        private bool _isToggled;

        public bool Toggled
        {
            get => _isToggled;
            set
            {
                if (_isToggled != value)
                {
                    _isToggled = value;
                    toggleSwitchObject.Image = _isToggled ? icons8_toggle_32_on : icons8_toggle_32_off;
                    stateLabel.Text = _isToggled ? "On" : "Off";
                    OnToggleChanged();
                }
            }
        }

        public ToggleSwitchControl()
        {
            InitializeComponent();

            toggleSwitchObject.Image = Toggled ? icons8_toggle_32_on : icons8_toggle_32_off;
            stateLabel.Text = Toggled ? "On" : "Off";
        }

        private void ToggleSwitchObject_Click(object sender, EventArgs e)
        {
            _isToggled = !_isToggled;
            toggleSwitchObject.Image.Dispose();
            toggleSwitchObject.Image = _isToggled ? icons8_toggle_32_on : icons8_toggle_32_off;
            stateLabel.Text = _isToggled ? "On" : "Off";
            OnToggleChanged();
        }

        private void StateLabel_TextChanged(object sender, EventArgs e)
        {
            var objects = (Label)sender!;
            if (objects.Text == "Off")
            {
                objects.ForeColor = SystemColors.ControlText;
            }
            else if (objects.Text == "On")
            {
                objects.ForeColor = Color.Firebrick;
            }
        }

        public event EventHandler? ToggleSwitchChanged;
        protected virtual void OnToggleChanged()
        {
            ToggleSwitchChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
