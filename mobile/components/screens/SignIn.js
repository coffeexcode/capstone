import React, { useState } from 'react';
import { KeyboardAvoidingView, StyleSheet, Image, TextInput, View, Platform, TouchableWithoutFeedback, Keyboard } from 'react-native';

// Fix relative imports
import CAText from '../core/CAText';
import CAButton from '../core/CAButton';
import Spacer from '../core/Spacer';
import logInImg from '../../assets/images/drawkit_login.jpg';

const text = {
  createAccountMessage: `Don't have an account? Create one `
}

export default function SignIn({ navigation }) {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const loginRequest = () => {
    // Optional: TODO send API request to authenticate
    // For POC/Demo purposes, authentication can be left out as the app's functionality is more important to showcase
    console.log(username);
    console.log(password);
    navigation.navigate('SelectView');
  }

  return (
    <KeyboardAvoidingView
      behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
      style={{ flex: 1 }}
    >
      <TouchableWithoutFeedback onPress={Keyboard.dismiss}>
        <View style={styles.container}>
          <Image source={logInImg} style={styles.splash}/>
          <Spacer size='lg'/>
          <CAText size='xlg'>Sign In</CAText>
          <Spacer size='md'/>
          <View style={styles.inputContainer}>
            <TextInput
              style={styles.input}
              placeholderTextColor='#A9A9A9'
              placeholder='Username'
              onChangeText={text => setUsername(text)}/>
          </View>
          <View style={styles.inputContainer}>
            <TextInput
              secureTextEntry
              style={styles.input}
              placeholderTextColor='#A9A9A9'
              text
              placeholder='Password'
              onChangeText={text => setPassword(text)}/>
          </View>
          <CAButton
            size='sm'
            title='Log in'
            onPress={loginRequest}
          />
          <Spacer size='md' />
          <CAText style={{ color: '#A9A9A9' }} size='xsm'>
            {text.createAccountMessage}
            <CAText
              style={{ textDecorationLine: 'underline'}}
              size='xsm'>here</CAText>
            </CAText>
        </View>
      </TouchableWithoutFeedback>
    </KeyboardAvoidingView>
  )
}

const styles = StyleSheet.create({
  input: {
    height: 45,
    fontSize: 16,
    color: 'black'
  },
  inputContainer: {
    width: '70%',
    borderRadius:15,
    borderBottomColor: '#6C63FF',
    borderBottomWidth: 1,
    height:55,
    marginBottom:20,
    justifyContent: 'center',
    padding:20
  },
  splash: {
    height: '18%',
    resizeMode: 'contain'
  },
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center'
  }
});
