FROM gitpod/workspace-base

# Source: https://docs.microsoft.com/dotnet/core/install/linux-scripted-manual#scripted-install
RUN mkdir -p /home/gitpod/dotnet && curl -fsSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --install-dir /home/gitpod/dotnet
ENV DOTNET_ROOT=/home/gitpod/dotnet
ENV PATH=/home/gitpod/dotnet:$PATH

RUN chmod +x /home/gitpod/.bashrc.d/110-dotnet


RUN npm install -g npm@latest

RUN npm i -g azure-functions-core-tools@4 --unsafe-perm true

RUN npm i -g @azure/static-web-apps-cli
