function Menu()
{
	this.height = 0;

	this.init = function(){
		this.getSize();
		this.openerListener();
	}

	// get size of the menu container
	this.getSize = function(){
		this.height = ( $('.menuItem').height() * $('#menu').find('.menuItem').length ) + 40;
	}

	this.openerListener = function()
	{
		var self = this;
		$('#menuOpener').click(function(){
			var menu = $('#menu');

			if(!menu.hasClass('menuOpened'))
			{
				menu.addClass('menuOpened');
				menu.css('height', self.height + 'px');
			}
			else
			{
				menu.removeClass('menuOpened');
				menu.css('height', '0px');
			}
		});
	}

	this.init();
}
