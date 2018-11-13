#!/bin/bash

echo "*** Portfolio Pusher ***"

cd portfolio/

git init

read -p "Enter your repository URL: " repo
git remote add origin $repo

git add .
git commit -m "Update new portfolio"
git push origin master

# echo $repo

cd -