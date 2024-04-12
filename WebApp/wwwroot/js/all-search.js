// search in all
$('#search_select').on('change', function() {
        var query = $('#search-inpit-all').val();
          if (query != "") {
                  $('#search-input-modal-resalt').css("background-image", "none");
                  
                  $.ajax({
                          type: "POST",
                          url: url('ajax/admin.search.html'),
                          data:'keyword='+$(this).val()+'&&cat='+$('#search_select').val(),
                          beforeSend: function(){
                                  $("#search-icon").css("background","url() no-repeat 3px");
                                  $("#search-icon").show();
                          },
                          success: function(data){
                                  $("#search-input-modal-resalt").show();
                                  $("#search-input-modal-resalt").html(data);
                          }
                  });
          } else {
                $('#search-input-modal-resalt').removeAttr('style');

                $.ajax({
                        type: "POST",
                        url: url('ajax/admin.search.html'),
                        data:'empty=true',
                        beforeSend: function(){
                                $("#search-icon").css("background","url() no-repeat 3px");
                                $("#search-icon").show();
                        },
                        success: function(data){
                                $("#search-input-modal-resalt").show();
                                $("#search-input-modal-resalt").html(data);
                        }
                });
          }
});
$("#search-inpit-all").keyup(function(){
        var query = $(this).val();
          if (query != "") {
                  $('#search-input-modal-resalt').css("background-image", "none");
                  
                  $.ajax({
                          type: "POST",
                          url: url('ajax/admin.search.html'),
                          data:'keyword='+$(this).val()+'&&cat='+$('#search_select').val(),
                          beforeSend: function(){
                                  $("#search-icon").css("background","url() no-repeat 3px");
                                  $("#search-icon").show();
                          },
                          success: function(data){
                                  $("#search-input-modal-resalt").show();
                                  $("#search-input-modal-resalt").html(data);
                          }
                  });
          } else {
                $('#search-input-modal-resalt').removeAttr('style');

                $.ajax({
                        type: "POST",
                        url: url('ajax/admin.search.html'),
                        data:'empty=true',
                        beforeSend: function(){
                                $("#search-icon").css("background","url() no-repeat 3px");
                                $("#search-icon").show();
                        },
                        success: function(data){
                                $("#search-input-modal-resalt").show();
                                $("#search-input-modal-resalt").html(data);
                        }
                });
          }
  });