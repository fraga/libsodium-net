#!/bin/bash
set -ev
lsb_release -a

echo 'mono --runtime=v4.0 ./packages/NUnit.Runners.2.6.3/tools/nunit-console.exe "$@"' > nunit-console.sh

mono --version
