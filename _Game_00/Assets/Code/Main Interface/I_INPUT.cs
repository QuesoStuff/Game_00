using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_INPUT
{

    bool input_iddle();

    bool input_move_up();

    bool input_move_down();

    bool input_move_left();

    bool input_move_right();

    bool input_shoot();

    bool input_charged_Shot();

    /*
      bool input_dash_up();

      bool input_dash_down();

      bool input_dash_left();

      bool input_dash_rignt();
      */

}
