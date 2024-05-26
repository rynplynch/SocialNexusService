
# Table of Contents

-   [Introduction](#org08c08d5)
-   [Configured For Azure AD](#org4cb4a90)
-   [Containerized](#org1cede37)



<a id="org08c08d5"></a>

# Introduction

This git repo was generated using the following command:

    dotnet new webapi --auth IndividualB2C --use-program-main -controllers


<a id="org4cb4a90"></a>

# Configured For Azure AD

That starter code was then configured to connect to SocialNexus Azure AD B2C instance in the *appsettings.json* file.


<a id="org1cede37"></a>

# Containerized

Wrote Dockerfile to create image of built service. Then took that image and hosted it in Kubernetes enviroment.

\*

