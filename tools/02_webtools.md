!SLIDE small
# Web stuff #

!SLIDE small smbullets
# Master Pages And Controls #
* New products are all using master pages.  Old products are getting this added.
* We should't reproduce page elements.  We should reuse templates/controls.
* Any pages not using masters should be, we just may need to tweak some javascript.
* These save a ton of time when maintaining/modifying look & feel.
* They also promote good SOC.  The page only handles its own concerns now.


!SLIDE small smbullets
# MVC #
* Our new products are all using MVC and it will probably get used for new dev in old products.
* Encourages good seperation of concerns between display and logic.
* If done right this will make supporting new devices (like tablets) much easier too.
* MVC supports Master Pages.  We should be using them for all navigation and layout.

!SLIDE small smbullets
# jQuery #
* Prototype and MSAjax are being phased out and replaced by jQuery.
* Makes doing JavaScript easy.  Tons of build in DOM manipulations.
* When adding jQuery to old pages with another library use noConflict().
* Anything we were doing with Infragistics we should probably use jQuery for going forward.

!SLIDE smaller code
# jQuery noConflict() #
    @@@javascript
    <script type="text/javascript">
      // This tells jQuery not to use the $ syntax in case Protype 
      // is using it 
      jQuery.noConflict();

      jQuery(document).ready(function() {

        // Use jQuery. instead of $. in no conflict mode.
        // When in doubt do it this way to avoid compatibility 
        // issues. 
        jQuery("input#someId").slideToggle();

      });
    </script>

!SLIDE smaller code
# jQuery Example #

<span style="font-size: 2em;">Script</span>
    @@@javascript
    <script type="text/javascript">
      // The live() method binds this event to anything matching the 
      // selector now or in the future.  Great if things will be 
      // added dynamically.
      $('form#myForm').live('submit', 
        function() {
          var myValue = $('form#myForm input#text1').val();
          DoSomething(myValue);
        }
      );
    </script>
 
<span style="font-size: 2em;">HTML</span>
    @@@html
    <form id="myForm">
      <input type="text" id="text1" />
    </form>

<span style="font-size: 2em;">Sidenote:  IDs are unique.  This is important.  Quit having more than one element with an<br/>ID on the same page.</span>
