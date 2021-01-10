import werkzeug
werkzeug.cached_property = werkzeug.utils.cached_property
from flask import Flask, Blueprint
from flask_restplus import Resource, Api
from flask import request, jsonify, make_response
import firebase_admin
from firebase_admin import credentials, firestore

app = Flask(__name__)
api = Api(version='1.0', title='Registration API',
          description='An API which allows interactivity with users')

namespace = api.namespace('users', description='Operations on user resources')

# initialize sdk
cred = credentials.Certificate("capstone-90db7-firebase-adminsdk-fgtvl-f294022ef1.json")
firebase_admin.initialize_app(cred)
# initialize firestore instance
firestore_db = firestore.client()

@namespace.route('/')
class UserCollection(Resource):
    def get(self):
        """
        Returns a list of users
        """
        l = get_users_list()
        return make_response(jsonify(l), 200)
    
    @api.response(201, "User successfully created")
    def post(self):
        """
        Create a new user
        """
        create_user(request.json)
        return None, 201


def get_users_list():
    snapshots = list(firestore_db.collection(u'users').get())
    li = []
    for snapshot in snapshots:
        li.append(snapshot.to_dict())
    return li

def create_user(data):
    firestore_db.collection(u'users').add(data)

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