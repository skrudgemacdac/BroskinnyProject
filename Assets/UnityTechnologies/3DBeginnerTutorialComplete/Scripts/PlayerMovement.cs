using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f; // Скорость поворота персонажа.

    Animator m_Animator; // Ссылка на компонент аниматора.
    Rigidbody m_Rigidbody; // Ссылка на компонент Rigidbody.
    AudioSource m_AudioSource; // Ссылка на компонент аудио.
    Vector3 m_Movement; // Вектор для хранения направления движения.
    Quaternion m_Rotation = Quaternion.identity; // Кватернион для хранения ориентации персонажа.

    void Start()
    {
        m_Animator = GetComponent<Animator>(); // Получение компонента аниматора при запуске скрипта.
        m_Rigidbody = GetComponent<Rigidbody>(); // Получение компонента Rigidbody при запуске скрипта.
        m_AudioSource = GetComponent<AudioSource>(); // Получение компонента аудио при запуске скрипта.
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Получение ввода по горизонтали (A и D).
        float vertical = Input.GetAxis("Vertical"); // Получение ввода по вертикали (W и S).

        m_Movement.Set(horizontal, 0f, vertical); // Создание вектора направления движения на основе ввода.
        m_Movement.Normalize(); // Нормализация вектора направления, чтобы сохранить постоянную скорость движения.

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f); // Проверка наличия ввода по горизонтали.
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f); // Проверка наличия ввода по вертикали.
        bool isWalking = hasHorizontalInput || hasVerticalInput; // Проверка, идет ли движение.
        m_Animator.SetBool("IsWalking", isWalking); // Установка состояния анимации "ходьба" на основе движения.

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play(); // Воспроизведение звука ходьбы, если персонаж двигается и звук не проигрывается.
            }
        }
        else
        {
            m_AudioSource.Stop(); // Остановка звука ходьбы, если персонаж не двигается.
        }

        // Вычисление ориентации персонажа на основе направления движения.
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        // Обновление позиции персонажа с учетом анимации и физики.
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);

        // Обновление ориентации персонажа с учетом анимации.
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}