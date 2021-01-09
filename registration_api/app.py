import werkzeug
werkzeug.cached_property = werkzeug.utils.cached_property
from flask import Flask, Blueprint
from flask_restplus import Resource, Api
from flask import request

app = Flask(__name__)
api = Api(version='1.0', title='Registration API',
          description='An API which allows interactivity with users')

namespace = api.namespace('users', description='Operations on user resources')

@namespace.route('/')
class UserCollection(Resource):
    def get(self):
        """
        Returns a list of users
        """
        return get_users_list()
    
    @api.response(201, "User successfully created")
    def post(self):
        """
        Create a new user
        """
        create_user(request.json)
        return None, 201


def get_users_list():
    print("PRINTING")

def create_user(data):
    name = data.get('name')
    print(name)

def start_app(app):
    bp = Blueprint('api', __name__, url_prefix='/api')
    api.init_app(bp)
    api.add_namespace(namespace)
    app.register_blueprint(bp)

def main():
    start_app(app)
    app.run()

if __name__ == '__main__':
    main()