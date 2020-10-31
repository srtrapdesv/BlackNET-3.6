  <nav class="navbar navbar-expand-lg  navbar-dark bg-dark">
    <a class="navbar-brand mr-1" href="index.php"><img src="favico.png" width="30" height="30" alt=""><?php echo APP_NAME; ?></a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="fas fa-bars"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav ml-auto">
        <li class="nav-item <?php echo $utils->link_active($page, "home"); ?>">
          <a class="nav-link" href="index.php">
            <span class="fa fa-home"></span> Home
          </a>
        </li>
        <li class="nav-item <?php echo $utils->link_active($page, "view_logs"); ?>">
          <a class="nav-link" href="viewlogs.php">
            <span class="fa fa-clipboard-check"></span> View Logs
          </a>
        </li>
        <li class="nav-item <?php echo $utils->link_active($page, "network_settings"); ?>">
          <a class="nav-link" href="settings.php">
            <span class="fa fa-wrench"></span> Network Settings
          </a>
        </li>
        <li class="nav-item <?php echo $utils->link_active($page, "update_user"); ?>">
          <a class="nav-link" href="updateUser.php">
            <span class="fa fa-user"></span> User Settings
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link" data-toggle="modal" data-target="#logoutModal"><span class="fa fa-sign-out-alt"></span> Logout</a>
        </li>
      </ul>
    </div>
  </nav>