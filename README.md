# evfind

## Quick Install

- cd to the directory you'd like to install the binaries in.
```zsh
➜  evfind pwd
/mnt/c/Users/Bryce/evfind
```

- Download the sources from the release page, place them in this directory. Using wget:
```zsh
wget https://github.com/bryce-s/evfind/releases/download/0.50/CommandLine.dll\
https://github.com/bryce-s/evfind/releases/download/0.50/Everything64.dll\
https://github.com/bryce-s/evfind/releases/download/0.50/evfind.deps.json\
https://github.com/bryce-s/evfind/releases/download/0.50/evfind.dll\
https://github.com/bryce-s/evfind/releases/download/0.50/evfind.exe\
https://github.com/bryce-s/evfind/releases/download/0.50/evfind.pdb\
https://github.com/bryce-s/evfind/releases/download/0.50/evfind.runtimeconfig.dev.json\
https://github.com/bryce-s/evfind/releases/download/0.50/evfind.runtimeconfig.json\
https://github.com/bryce-s/evfind/archive/0.50.zip\
```
- Finally, create a shortcut to use evfind in your terminal:
 ```zsh
 # append alias of realpath of evfind.exe to shell rc file:
 ➜  evfind echo "alias evfind=$(realpath evfind.exe)" >> ~/.$(ps -p $$ -oargs=)rc
 ```

