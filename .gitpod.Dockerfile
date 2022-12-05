FROM gitpod/workspace-dotnet:latest

RUN npm i -g @azure/static-web-apps-cli
# Install Azure Function Core Tools
RUN npm i -g azure-functions-core-tools@4 --unsafe-perm true

# Install jest
#RUN npm i -g jest