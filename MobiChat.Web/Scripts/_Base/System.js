function System()
{

  this._mode = false;

  // SUMMARY: Constructor
  this._init = function () {
    var self = this;
    $(document).ready(function () { self._onLoad(); });
  };

  // SUMMARY: On document loaded
  this._onLoad = function () {
    var self = this;
    //this.AdjustFooter();
    this.ConfigureAnchors();
    this.Remove();
    this.OnKeyboard();

    setTimeout(function () { self.AdjustFooter(); }, 300); // fix
    setTimeout(function () { self.AdjustFooter(); }, 1000); // fix
  };

  // SUMMARY: removes all elements with class .__remove
  this.Remove = function () {
    $('.__remove').each(function () {
      $(this).remove();
    });
  };

  // SUMMARY: Generic method for getting screen size
  this.BrowserSize = function () {
    return window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
  }

  // SUMMARY: Creates ID with given prefix (prefix_id)
  this.ID = function (prefix) {
    if (typeof prefix == undefined) prefix = ""; else prefix += "_";
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    for (var i = 0; i < 15; i++) text += possible.charAt(Math.floor(Math.random() * possible.length));
    return prefix + text;
  }

  // SUMMARY: Get random number from min to max
  this.Random = function (min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }
  
  // SUMMARY: Returns true ? false, if is in template mode or not
  this.Template = function () {
    if (typeof __mode !== 'undefined' && __mode != 'null') {
      this._mode = __mode == 'True' ? true : false;
      __mode = 'null';
    }

    return this._mode;
  };

  this.init();
}