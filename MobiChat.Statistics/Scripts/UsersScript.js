function editUser() {

  var usertype = $('#usertype option:selected').attr('utype');
  var userid = $('#userid').val();
  var username = $('#username').val();
 // var usertype = $('#usertype').find(":selected").text();
  var userstatus = $('#userstatus').find(":selected").text();

  $.ajax({
    url: '/Users/EditUser',
    chache: false,
    method: 'POST',
    data: {
      id: userid,
      name: username,
      type: usertype,
      status: userstatus
    },
    success: function (response) {
      window.location.href = 'http://localhost:50945/Users';
    },
    error: function () {
      alert("error");
    }
  });
}
  
  
  
function createUser() {
  var p1 = $('#passw').val();
  var p2 = $('#reppassw').val();
  if (p1 != p2) {
    console.log("err");
    return;
  } 

  var username = $('#username').val();
  var userPassword = $('#reppassw').val();
  var usertype = $('#usertype option:selected').attr('utype');
  var userstatus = $('#userstatus').find(":selected").text();
  console.log(username + " " + userPassword + " " + usertype +" " + userstatus);

  $.ajax({
    url: '/Users/CreateUser',
    chache: false,
    method: 'POST',
    data: {
      name: username,
      type: usertype,
      status: userstatus,
      password: userPassword
    },
    success: function (response) {
      console.log(response);
    },
    error: function () {
      alert("error");
    }
  });

}