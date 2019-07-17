function Appender() {

  this.count = 0; // SUMMARY: total number of content
  this.displayed = 0; // displayed number of content
  this.defaultDisplay = 0;

	this.init = function()
	{

	  if (this.displayed >= this.count)
	    $('#loadMore').remove();
	  else
	    this.listener();

	}

	this.listener = function(){
		var self = this;
		$('#loadMore').click(function () {
		  $.ajax({
		    url: 'home/loadmore?d=' + self.displayed + '&g=' + self.defaultDisplay,
		    method: 'POST',
		    data: {},
		    success:function(response)
		    {
		      $('#profileHolder').append(response);
		      self.displayed = $('.chatProfile').length;

		      if (self.displayed >= self.count)
		        $('#loadMore').remove();

		    }
		  });
		});
	}

}
