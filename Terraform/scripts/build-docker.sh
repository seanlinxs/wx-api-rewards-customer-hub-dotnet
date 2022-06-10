#!/bin/bash
readonly service="$1"
readonly project_id="$2"

PROJECT_ROOT=../..

rm -fr $PROJECT_ROOT/obj
rm -fr $PROJECT_ROOT/bin
docker build -t "gcr.io/$project_id/$service" $PROJECT_ROOT -f $PROJECT_ROOT/Dockerfile --build-arg "SERVICE=$service"
docker push "gcr.io/$project_id/$service"
