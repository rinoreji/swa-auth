FROM gitpod/workspace-dotnet

RUN npm install -g npm@latest

RUN npm i -g @azure/static-web-apps-cli

RUN npm i -g azure-functions-core-tools@4 --unsafe-perm true