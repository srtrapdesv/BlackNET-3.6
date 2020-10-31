<?php
include_once 'classes/Database.php';
include_once APP_PATH . '/classes/User.php';
include_once APP_PATH . '/classes/Mailer.php';
include_once APP_PATH . '/classes/ResetPassword.php';
include_once APP_PATH . '/classes/Utils.php';
include_once APP_PATH . '/logic/resetQuestionLogic.php';
include_once APP_PATH . '/includes/questions.php';
?>
<!DOCTYPE html>
<html lang="en">

<head>
  <?php include_once 'components/meta.php';?>
  <title><?php echo APP_NAME; ?> - Reset Password</title>
  <?php include_once 'components/css.php';?>
</head>

<body class="bg-dark">

  <div class="container">
    <div class="card card-login mx-auto mt-5">
      <div class="card-header">Security Question</div>
      <div class="card-body">
        <?php if (isset($msg)): ?>
          <?php $utils->show_alert($msg, "danger", "times-circle");?>
        <?php endif;?>
        <div class="text-center mb-4">

          <h4>Security Question</h4>
          <p>Please enter the answer to your security question</p>
        </div>
        <form method="POST">
          <div class="form-group">
            <label><?php echo $questions[$userQuestion->question]; ?></label>
            <div class="form-label-group">
              <input type="text" name="answer" id="answer" class="form-control" placeholder="Security Question's Answer" required="required" autofocus="autofocus">
              <label for="answer">Security Question's Answer</label>
            </div>
          </div>
          <button class="btn btn-primary btn-block" type="submit">Next Step</button>
        </form>
        <div class="text-center">
          <a class="d-block small mt-3" href="login.php">Login Page</a>
        </div>
      </div>
    </div>
  </div>

  <?php include_once 'components/js.php';?>

</body>

</html>