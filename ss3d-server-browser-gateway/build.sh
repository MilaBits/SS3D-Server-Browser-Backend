docker build -t millybits/ss3d-server-browser-server .
docker run -it --rm -p 8080:80 --name ss3d-server-browser-server ss3d-server-browser-server