FROM gitpod/workspace-dotnet

RUN npm i -g @azure/static-web-apps-cli
# Install Azure Function Core Tools
#RUN npm i -g azure-functions-core-tools@3 --unsafe-perm true

# Install jest
#RUN npm i -g jest