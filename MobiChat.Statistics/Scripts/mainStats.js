function select() {
  var time = $('#selectTime').find(":selected").attr('custom');

  $.ajax({
    url: '/Statistic/Table',
    chache: false,
    method: 'POST',
    data: {
      time: time
    },
    success: function (response) {

      $('#tablediv').html(response);

    },
    error: function () {
      alert("Greska, bla bla");
    }
  });
}
  
function fromTo() {
   
  var datefrom = $('#datefrom').val();
  var dateto = $('#dateto').val();
  var selectSplitTime = $('#selectSplitTime').find(":selected").attr('custom');
  console.log(selectSplitTime + " " + datefrom)
  if (selectSplitTime == 'null')
  {
    selectSplitTime = 'day';
  }

  if (isNaN(Date.parse(datefrom)) || isNaN(Date.parse(dateto)))
  {  
    return alert("Empty string can't be converted to DateTime");
  }  
 
  $.ajax({
    url: '/Statistic/SplitFunction',
    chache: false,
    method: 'POST',
    data: {
      datefrom: datefrom,
      dateto: dateto,
      split: selectSplitTime
    },
    success: function (response) {
      console.log(response);
      $('#tablediv').html(response);
    },
    error: function () {
      alert("Greska, bla bla");
    }
  });
}