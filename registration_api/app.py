import werkzeug
werkzeug.cached_property = werkzeug.utils.cached_property
from flask import Flask, Blueprint
from flask_restplus import Resource, Api
from registration_api.api.endpoints.users import namespace as users_namespace


app = Flask(__name__)
api = Api(version='1.0', title='Registration API',
          description='An API which allows interactivity with users')

def start_app(app):
    bp = Blueprint('api', __name__, url_prefix='/api')
    api.init_app(bp)
    api.add_namespace(users_namespace)
    app.register_blueprint(bp)

def main():
    start_app(app)
    app.run()

if __name__ == '__main__':
    main()