import React, { useState } from 'react';
import { StyleSheet, Image, TextInput, View } from 'react-native';

// Fix relative imports
import CAText from '../core/CAText';
import CAButton from '../core/CAButton';
import Spacer from '../core/Spacer';
import logInImg from '../../assets/images/drawkit_login.jpg';

export default function SignIn() {
  const createAccountMsg = "Don't have an account? Create one ";
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const loginRequest = () => {
    // TODO send API request to authenticate
    console.log(username);
    console.log(password);
  }

  return (
    <View style={styles.container}>
      <Image source={logInImg} style={styles.splash}/>
      <Spacer size="lg"/>
      <CAText size="xlg">Sign In</CAText>
      <Spacer size="md"/>
      <View style={styles.inputContainer}>
        <TextInput
          style={styles.input}
          placeholderTextColor='#A9A9A9'
          placeholder="Username"
          onChangeText={text => setUsername(text)}/>
      </View>
      <View style={styles.inputContainer}>
        <TextInput
          secureTextEntry
          style={styles.input}
          placeholderTextColor='#A9A9A9'
          text
          placeholder="Password"
          onChangeText={text => setPassword(text)}/>
      </View>
      <CAButton
        size="sm"
        title="Log in"
        onPress={loginRequest}
      />
      <Spacer size=""/>
      <CAText style={{ color: '#A9A9A9' }} size="xsm">
        {createAccountMsg}
        <CAText
          style={{ textDecorationLine: 'underline'}}
          size="xsm">here</CAText>
        </CAText>
    </View>
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
    justifyContent:"center",
    padding:20
  },
  splash: {
    height: "18%",
    resizeMode: 'contain'
  },
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center'
  }
});
