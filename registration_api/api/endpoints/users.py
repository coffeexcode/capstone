from registration_api.app import api
from registration_api.api.implementation import get_users_list, create_user
from registration_api.app import namespace
from flask import request
from flask_restplus import Resource

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

