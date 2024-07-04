<template>
  <q-layout>
    <q-page-container>
      <q-page class="flex flex-center column">
        <div class="q-pa-md row items-start q-gutter-md">
          <q-card class="my-card inset-shadow-down shadow-10 asd" style="width: 350px; color: white">
            <div class="flex flex-center">
              <h3 class="q-ma-md">Registration</h3>
              <p>Fill out the form carefully for registration</p>
            </div>
            <q-separator />
            <!-- Username Input -->
            <q-card-section class="q-gutter-lg">
              <q-input dark v-model="username" label="Username" color="white">
                <template v-slot:prepend>
                  <q-icon name="person" />
                </template>
              </q-input>
              <!-- Email Input -->
              <q-input dark v-model="email" label="Email" color="white">
                <template v-slot:prepend>
                  <q-icon name="email" />
                </template>
              </q-input>
              <!-- Password Input -->
              <q-input dark v-model="password" label="Password" color="white">
                <template v-slot:prepend>
                  <q-icon name="lock" />
                </template>
              </q-input>
              <!-- Confirm Password Input -->
              <q-input dark v-model="repeatPassword" label="Confirm Password" color="white">
                <template v-slot:prepend>
                  <q-icon name="lock_reset" />
                </template>
              </q-input>
              <!-- Student ID Input -->
              <q-input dark v-model="studentId" label="Student ID" color="white">
                <template v-slot:prepend>
                  <q-icon name="fingerprint" />
                </template>
              </q-input>
            </q-card-section>

            <q-separator />

            <!-- Button -->
            <q-card-actions vertical>
              <q-btn flat style="background: #21ba45" @click="registerUser">Zarejestruj się</q-btn>
            </q-card-actions>

            <div class="flex flex-center q-pa-md">
              <p class="q-ma-none">Already have an account? &nbsp;</p>
              <div></div>
              <router-link to="/login" style="color: green"> Sign in.</router-link>
            </div>
          </q-card>
        </div>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { UserService, UserSignUp } from 'src/API/UserService';
import { useQuasar } from 'quasar';

const $q = useQuasar();

const username = ref<string>('');
const email = ref<string>('');
const password = ref<string>('');
const repeatPassword = ref<string>('');
const studentId = ref<string>('');

const registerUser = async () => {
  if (password.value !== repeatPassword.value) {
    $q.notify({
      type: 'negative',
      message: 'Passwords do not match',
    });
    return;
  }

  try {
    const data: UserSignUp = {
      username: username.value,
      email: email.value,
      password: password.value,
      repeatPassword: repeatPassword.value,
      studentId: studentId.value,
    };
    const response = await UserService.SignUp(data);

    $q.notify({ type: 'positive', message: response.toString() });
  } catch (error: any) {
    $q.notify({ type: 'negative', message: error.response.data });
  }
};
</script>
