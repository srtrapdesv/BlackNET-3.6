<?php
include_once 'session.php';
include_once APP_PATH . '/classes/Clients.php';
include_once APP_PATH . '/classes/POST.php';
include_once APP_PATH . '/classes/blackupload/Upload.php';
include_once APP_PATH . '/logic/sendCommandLogic.php';
?>
<!DOCTYPE html>
<html lang="en">

<head>
  <?php include_once 'components/meta.php';?>
  <title><?php echo APP_NAME; ?> - Execute Command</title>
  <?php include_once 'components/css.php';?>
</head>

<body id="page-top">
  <?php include_once 'components/header.php';?>
  <div id="wrapper">
    <div id="content-wrapper">
      <div class="container-fluid">
        <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">Command Menu</a>
          </li>
        </ol>
        <div class="card mb-3">
          <div class="card-header">
            <i class="fas fa-bolt"></i>
            Command Menu
          </div>
          <div class="card-body">
            <form method="POST" <?php echo (in_array($_POST['command'], $upload_required)) ? 'enctype="multipart/form-data"' : null; ?>>
              <div class="container container-special">
                <?php include_once 'components/commandController.php';?>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>

  <?php include_once 'components/footer.php';?>

  <?php include_once 'components/js.php';?>

  <script>
  jQuery(document).ready(function ($) {
    $(".custom-file-input").on("change", function(){
      var fileName = $(this).val().split("\\").pop();
      $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
    });

    $('#thread').on("input", function() {
      $('.thread').val(this.value);
    }).trigger("change");

    $('#timeout').on("input", function() {
      $('.timeout').val(this.value);
    }).trigger("change");

    $("select[name=attacktype]").change(function () {
      $("select[name=attacktype] option:selected").each(function () {
        var value = $(this).val();
        if (value == "TCP Attack") {
          $("#port, #portlabel, #portdesc").show();
        } else {
          $("#port, #portlabel, #portdesc").hide();
        }
      });
    });

    $("input[name=hasoutput]").click(function () {
      $("input[name=hasoutput]").each(function () {
        var value = $(this).prop("checked");
        var bool=$("#outputType").is(":hidden");
        if(value == true) {
          $("#outputType").toggleClass('hidden');
          $("#outputType").attr('hidden',!bool);
        } else if(value == false) {
          $("#outputType").toggleClass('hidden');
          $("#outputType").attr('hidden',!bool);
        } else {
          alert("error");
        }
      });
    });
  });
</script>
</body>

</html>