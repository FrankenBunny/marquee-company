# Check parameter was provided
if [ -z "$1" ]; then
  echo "No environment variable was given. Use one of [build, dev, prod]."
  exit 1
fi

case $1 in 
  "build" )
    echo "Initializing environment..."
    export $(grep -v "^#" .env.development | xargs)
    docker-compose -f docker-compose.development.yml up --build -d postgres
    echo "PostgreSQL database started..."
    docker-compose -f docker-compose.development.yml up --build -d api
    echo "Api started..."
    echo "Swagger accessible through http://localhost:8090/swagger";;
#    docker-compose -f docker-compose.development.yml up --build -d web
#    echo "Web application started"
#    echo "accessible through http://localhost:5173";;
  "dev" )
    echo "Starting development environment..."
    export $(grep -v "^#" .env.development | xargs)
    docker-compose -f docker-compose.development.yml up -d postgres
    echo "PostgreSQL database started..."
    docker-compose -f docker-compose.development.yml up -d api
    echo "Api started..."
    echo "Swagger accessible through http://localhost:8090/swagger";;
#    docker-compose -f docker-compose.development.yml up -d web
#    echo "Web application started"
#    echo "accessible through http://localhost:5173";;
esac

# Load environment variables
#export $(grep -v "^#" .env.development | xargs) && docker-compose up --build postgres