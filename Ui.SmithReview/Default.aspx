﻿<%@ Page Language="C#" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>SmithReviews</title>
    
    <link href="css/smithReview.style.css" rel="stylesheet" type="text/css">
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css">
</head>
<body>
    <div class="container">
        <div class="header clearfix">
            <nav>
                <ul class="nav nav-pills pull-right">
                <li role="presentation" class="active"><a href="#">Home</a></li>
                </ul>
            </nav>
            <h3 class="text-muted">Smith Reviews Sample</h3>
        </div>

        <div class="jumbotron">
            <h1><i class="vso-icon" aria-hidden="true"></i> Gus + TFS</h1>
            <p class="lead">See how Gus uses TFS tasks and storyboarding to manage projects and deliver in a team.</p>
            <p>
                <a class="btn btn-lg btn-success" href="https://guscrawford.visualstudio.com/SmithReview/" target="_blank" role="button">
                    <i class="fa fa-sign-in" aria-hidden="true"></i> Join SmithReview <small>guscrawford.visualstudio.com/SmithReview</small></a>
            </p>
            <p>
                <a class="btn btn-sm btn-primary" href="mailto:crawford.gus@gmail.com?subject=Requesting%20Access%20To%20SmithReview" target="_blank" role="button">
                    <i class="fa fa-comment" aria-hidden="true"></i> Request Access to TFS Portal</a>
                <a class="btn btn-sm btn-default" href="https://github.com" target="_blank" role="button">
                    <i class="fa fa-github" aria-hidden="true"></i> Clone from GitHub</a>
            </p>
            <p class="text-muted">
                Complete source and sprint-burndown available at TFS web-portal<br>
                <small>
                    You can clone this source now from <a href="http://github.com">GitHub</a>, or send an <a href="mailto:crawford.gus@gmail.com?subject=Requesting%20Access%20To%20SmithReview">email</a> with a Microsoft email to be added to the team.
                </small>
            </p>
        </div>

        <div ng-view></div>

        <footer class="footer">
            <p>&copy; 2017 Gus Crawford for Review by Smith, Inc.</p>
        </footer>
    </div>
    <script src="js/ui.smithReview.js"></script>
    <script>
        angular.module('app.smithReview').constant('restEndpoint',"<asp:Literal runat='server' Text='<%$ appSettings:SmithReviewsApi%>' />");
    </script>
</body>
</html>
