<?php
include_once 'session.php';
include_once APP_PATH . '/classes/Settings.php';
include_once APP_PATH . '/classes/Mailer.php';
include_once APP_PATH . '/logic/settingsLogic.php';
?>
<!DOCTYPE html>
<html lang="en">

<head>
  <?php include_once 'components/meta.php';?>
  <title><?php echo APP_NAME; ?> - Network Settings</title>
  <?php include_once 'components/css.php';?>
</head>

<body id="page-top">
  <?php include_once 'components/header.php';?>
  <div id="wrapper">
    <div id="content-wrapper">
      <div class="container-fluid">
        <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="#">User Settings</a>
          </li>
        </ol>
        <div class="card mb-3">
          <div class="card-header">
            <i class="fas  fa-user-circle"></i>
            Update Settings</div>
          <div class="card-body">
            <form id="Form1" name="Form1" method="POST" action="includes/updateSettings.php">

              <div class="container container-special">
                <?php if (isset($_GET['msg']) && $_GET['msg'] == "yes"): ?>
                  <?php $utils->show_alert("Settings Has Been Updated", "success", "check-circle");?>
                <?php endif;?>

                <?php if (isset($_GET['msg']) && $_GET['msg'] == "csrf"): ?>
                  <?php $utils->show_alert("CSRF Token is invalid.", "danger", "times-circle");?>
                <?php endif;?>
              </div>
              <div class="container container-special">
                <div class="align-content-center justify-content-center">
                  <?php $utils->show_input("csrf", $utils->sanitize($_SESSION['csrf']));?>

                  <div class="form-group">
                      <div class="custom-control custom-switch custom-control-right">
                        <input type="checkbox" class="custom-control-input" id="panel_status" name="panel_status" <?php echo ($getSettings['panel_status'] == "on") ? 'checked' : null; ?>>
                        <label class="custom-control-label" for="panel_status">Panel Status: </label>
                      </div>
                  </div>

                  <hr>


                    <div class="form-group">
                      <div class="custom-control custom-switch custom-control-right">
                        <input class="custom-control-input" id="darkmode" name="darkmode" type="checkbox" <?php echo (isset($_SESSION['darkmode'])) ? 'checked' : null; ?>>
                        <label class="custom-control-label" for="darkmode">Dark Mode: </label>
                      </div>
                    </div>

                  <hr>

                  <div class="form-group">
                    <div class="custom-control custom-switch custom-control-right">
                      <input class="custom-control-input" id="recaptcha_status" name="recaptcha_status" type="checkbox" <?php echo ($getSettings['recaptcha_status'] == "on") ? 'checked' : null; ?>>
                      <label class="custom-control-label" for="recaptcha_status">Enable reCAPTCHA: </label>
                    </div>
                  </div>

                  <div class="form-group">
                    <div class="form-label-group">
                      <input class="form-control" id="recaptchapublic" type="text" name="recaptchapublic" placeholder="reCAPTCHA Public Key" value="<?php echo $getSettings['recaptchapublic']; ?>">
                      <label for="recaptchapublic">reCAPTCHA Public Key</label>
                    </div>
                  </div>

                  <div class="form-group">
                    <div class="form-label-group">
                      <input class="form-control" id="recaptchaprivate" type="text" name="recaptchaprivate" placeholder="reCAPTCHA Public Key" value="<?php echo $getSettings['recaptchaprivate']; ?>">
                      <label for="recaptchaprivate">reCAPTCHA Private Key</label>
                    </div>
                  </div>
                  <button for="Form1" name="Form1" class="btn btn-primary btn-block">Update Settings</button>
                </div>
                <hr>
              </div>
            </form>

            <form id="Form2" name="Form2" method="POST" action="includes/updateSettings.php" class="pt-2">
              <div class="container container-special" class="align-content-center justify-content-center">
                  <?php $utils->show_input("csrf", $utils->sanitize($_SESSION['csrf']));?>
                <div class="form-group">
                  <div class="custom-control custom-switch custom-control-right">
                    <input class="custom-control-input" id="smtp_status" name="smtp_status" type="checkbox" <?php echo ($getSMTP['smtp_status'] == "on") ? 'checked' : null; ?>>
                    <label class="custom-control-label" for="smtp_status">Enable SMTP: </label>
                  </div>
                </div>

                <div class="form-group">
                  <div class="form-label-group">
                    <input class="form-control" type="text" id="smtp_host" name="smtp_host" placeholder="SMTP Host" value="<?php echo $getSMTP['smtp_host']; ?>">
                    <label for="smtp_host">SMTP Host</label>
                  </div>
                </div>

                <div class="form-group">
                  <div class="form-label-group">
                    <input class="form-control" type="text" id="smtp_username" name="smtp_username" placeholder="SMTP User" value="<?php echo $getSMTP['smtp_username']; ?>">
                    <label for="smtp_username">SMTP User</label>
                  </div>
                </div>

                <div class="form-group">
                  <div class="form-label-group">
                    <input class="form-control" type="password" id="smtp_password" name="smtp_password" placeholder="SMTP Password" value="<?php echo base64_decode($getSMTP['smtp_password']); ?>">
                    <label for="smtp_password">SMTP Password</label>
                  </div>
                </div>

                <div class="form-group">
                  <select label="Select a Security type" name="smtp_security" id="smtp_security" class="form-control">
                    <option>Select a Security type</option>
                    <?php foreach ($smtp_types as $smtp_type): ?>
                    <option value="<?php echo strtolower($smtp_type); ?>" <?php echo ($getSMTP['smtp_security'] == strtolower($smtp_type)) ? "selected" : null; ?>><?php echo $smtp_type ?></option>
                  <?php endforeach;?>
                  </select>
                </div>

                <div class="form-group">
                  <div class="form-label-group">
                    <input class="form-control" type="text" id="smtp_port" name="smtp_port" placeholder="SMTP Port" value="<?php echo $getSMTP['smtp_port']; ?>">
                    <label for="smtp_port">SMTP Port</label>
                  </div>
                </div>
                <button for="Form2" name="Form2" class="btn btn-primary btn-block">Update SMTP</button>
              </div>
            </form>
          </div>

        </div>
      </div>
    </div>
  </div>

  <?php include_once 'components/footer.php';?>

  <?php include_once 'components/js.php';?>
</body>

</html>