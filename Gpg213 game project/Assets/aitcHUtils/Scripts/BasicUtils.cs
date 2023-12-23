//using System;
//using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace aitcHUtils
{
    [System.Serializable]
    public class Range 
    {
        public float Min { get { return min; } }
        [SerializeField] float min;
        public float Max { get { return max; } }
        [SerializeField] float max;

        public Range(float min, float max) 
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Return a random number between min[inclusive] and max[inclusive]
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float GetRandom(float min, float max) 
        {
            return Random.Range(min, max);
        }

        /// <summary>
        /// Return a random number between min[inclusive] and max[exclusive]
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandom(int min, int max)
        {
            return Random.Range(min, max);
        }

        public static int Clamp(int value, Range range)
        {
            if (value > range.Max)
                return (int)range.Max;
            else if (value < range.Min)
                return (int)range.Min;

            return value;
        }

        public static float Clamp(float value, Range range)
        {
            if (value > range.Max)
                return range.Max;
            else if (value < range.Min)
                return range.Min;

            return value;
        }
    }

    public static class Randoms
    {
        public static string RandomChar(bool isUpperCase = true)
        {
            string[] chars = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            string character = chars[Random.Range(0, 26)];

            if (!isUpperCase) return character.ToLower();

            return character;
        }

        public static string RandomWord(int wordLength, bool isUpperCase = true)
        {
            int i = 0;
            string x;
            string word = "";
            while (i < wordLength) 
            {
                x = Randoms.RandomChar();
                word = word + x;
                i++;
            }

            if (!isUpperCase) return word.ToLower();

            return word;
        }

        public static string RandomNumbers(int numberLength)
        {
            int i = 0;
            string x;
            string num = "";
            string[] nums = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            while (i < numberLength)
            {
                x = nums[Random.Range(0, 10)];
                num = num + x;
                i++;
            }

            return num;
        }

        public static Vector2 RandomVector2(Vector2 minPos, Vector2 maxPos)
        {
            float x = Random.Range(minPos.x, maxPos.x);
            float y = Random.Range(minPos.y, maxPos.y);

            return new Vector2(x, y);
        }
    }

    //public class MonoBehaviourExtended : MonoBehaviour
    //{
    //    /// <summary>
    //    /// Toggles the active state of the object
    //    /// </summary>
    //    /// <param name="obj">The object to be toggled</param>
    //    public void ToggleActiveState(GameObject obj) 
    //    {
    //        if (obj.activeInHierarchy) obj.SetActive(false);
    //        else if (!obj.activeInHierarchy) obj.SetActive(true);
    //    }

    //    public static void TypeText(Text _textObject, string _typedText, int _frameInterval)
    //    {
    //        _textObject.text = "";
    //        //startc
    //    }



    //}

    public class UIUtils
    {
        /// <summary>
        /// Returns the anchored position with Anchor Min and desired center. BOth achorMin and anchorMax should be equal
        /// </summary>
        /// <param name="obj">The object to take for center pos</param>
        /// <param name="desiredCenterX">desired anchorMin.x</param>
        /// <param name="desiredCenterY">desired anchorMin.y</param>
        /// <returns>The final vector2 with anchor centered on desired</returns>
        public static Vector2 CenterAnchoredPos(RectTransform obj, float desiredCenterX, float desiredCenterY)
        {
            Canvas canvas = obj.GetComponentInParent<Canvas>();
            float x;
            float y;
            bool doSubtractX = desiredCenterX > obj.anchorMin.x;
            bool doSubtractY = desiredCenterY > obj.anchorMin.y;

            float offsetX = obj.anchorMin.x - desiredCenterX;
            float offsetY = obj.anchorMin.y - desiredCenterY;

            if(!doSubtractX)
                x = obj.anchoredPosition.x + (canvas.GetComponent<RectTransform>().sizeDelta.x * offsetX);
            else 
                x = obj.anchoredPosition.x - (canvas.GetComponent<RectTransform>().sizeDelta.x * offsetX);

            if (!doSubtractY)
                y = obj.anchoredPosition.y + (canvas.GetComponent<RectTransform>().sizeDelta.y * offsetY);
            else
                y = obj.anchoredPosition.y - (canvas.GetComponent<RectTransform>().sizeDelta.y * offsetY);

            return new Vector2(x, y);
        }

        /// <summary>
        /// Types the text from first letter to the last
        /// </summary>
        /// <param name="_monoBehaviourHandler">MonoBehaviour reference. Just use "this" keyword</param>
        /// <param name="_textObject">The Text component in which the text is typed</param>
        /// <param name="_typedText">The text to be typed</param>
        /// <param name="_letterInterval">Delay between typing each letter</param>
        public static void TypeText(MonoBehaviour _monoBehaviourHandler, Text _textObject, string _typedText, System.Action onFinish ,AudioSource source = null, float _letterInterval = 0.1f)
        {
            _textObject.text = "";
            _monoBehaviourHandler.StartCoroutine(coroutine_TypingText(_textObject, _typedText, _letterInterval, source, onFinish));
        }

        /// <summary>
        /// Runs the action code after delay. If delay = 0, code with run after 1 frame.
        /// </summary>
        /// <param name="behaviour">The behaviour on which coroutine run. Use "this" in most cases</param>
        /// <param name="code">The code to run</param>
        /// <param name="delay">The time to wait</param>
        public static Coroutine MoveTowardsUI(MonoBehaviour behaviour, RectTransform rect, Vector2 finalAnchoredPos, float maxDistanceDelta, System.Action action = null)
        {
            return behaviour.StartCoroutine(coroutine_MoveTowardsUI(rect, finalAnchoredPos, maxDistanceDelta, action));
        }

        /// <summary>
        /// Runs the action code after delay. If delay = 0, code with run after 1 frame.
        /// </summary>
        /// <param name="behaviour">The behaviour on which coroutine run. Use "this" in most cases</param>
        /// <param name="action">The code to run</param>
        /// <param name="IsLocalScale">Whether to change the local scale or the width & height of UI</param>
        public static Coroutine ScaleToUI(MonoBehaviour behaviour, RectTransform rect, Vector2 finalAnchoredPos, float Speed, bool IsLocalScale = false, System.Action action = null)
        {
            return behaviour.StartCoroutine(coroutineScaleToUI(rect, finalAnchoredPos, Speed, IsLocalScale, action));
        }

        /// <summary>
        /// Fade in or out the alpha of CanvasGroup in a given time
        /// </summary>
        /// <param name="behaviour">The behaviour on which coroutine run. Use "this" in most cases</param>
        /// <param name="uiToFade">The CanvasGroup to transition</param>
        /// <param name="fadeIn">Fade in or Fade out</param>
        /// <param name="time">The time to finish transition</param>
        /// <param name="action">Code to execute on completion. null by default</param>
        /// <returns>The coroutine on which it is placed</returns>
        public static Coroutine FadeTransition(MonoBehaviour behaviour,  CanvasGroup uiToFade, bool fadeIn, float time, System.Action action = null) 
        {
            return behaviour.StartCoroutine(coroutine_FadeTransition(uiToFade, fadeIn, time, action));
        }


        #region Coroutines
        static IEnumerator coroutine_FadeTransition(CanvasGroup _uiToFade, bool _fadeIn, float _time, System.Action _action)
        {
            if (_fadeIn)
            {
                _uiToFade.alpha = 0;
                while (_uiToFade.alpha < 0.99f)
                {
                    _uiToFade.alpha += ((1.0f / _time) * Time.deltaTime);
                    yield return null;
                }
            }
            else
            {
                _uiToFade.alpha = 1.0f;
                while (_uiToFade.alpha > 0.01f)
                {
                    _uiToFade.alpha -= ((1.0f / _time) * Time.deltaTime);
                    yield return null;
                }
            }

            yield return null;

            if (_action != null)
            {
                _action.Invoke();
            }
        }

        static IEnumerator coroutine_TypingText(Text _textObject, string _typedText, float _letterInterval, AudioSource source, System.Action onFinish)
        {
            for (int i = 0; i < _typedText.Length; i++)
            {
                yield return new WaitForSeconds(_letterInterval);
                _textObject.text += _typedText[i];

                if (source != null && _typedText[i].ToString() != " ") source.Play();
            }

            yield return null;
            onFinish?.Invoke();
        }
        static IEnumerator coroutine_MoveTowardsUI(RectTransform rect, Vector2 finalAnchoredPos, float maxDistanceDelta, System.Action action)
        {
            while (rect.anchoredPosition.x != finalAnchoredPos.x || rect.anchoredPosition.y != finalAnchoredPos.y)
            {
                rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, finalAnchoredPos, maxDistanceDelta);
                yield return null;
            }
            yield return null;

            if (action != null)
            {
                action.Invoke();
            }
        }
        static IEnumerator coroutineScaleToUI(RectTransform rect, Vector2 finalAnchoredPos, float Speed, bool IsLocalScale, System.Action action)
        {
            bool isIncreaseX;
            bool isIncreaseY;

            if (IsLocalScale)
            {
                isIncreaseX = finalAnchoredPos.x > rect.localScale.x;
                isIncreaseY = finalAnchoredPos.y > rect.localScale.y;

                while (rect.localScale.x != finalAnchoredPos.x || rect.localScale.y != finalAnchoredPos.y)
                {
                    if (isIncreaseY)
                    {
                        rect.gameObject.transform.localScale += Vector3.up * Speed * Time.deltaTime;
                        if (rect.localScale.y > finalAnchoredPos.y)
                            rect.gameObject.transform.localScale = new Vector3(rect.gameObject.transform.localScale.x, finalAnchoredPos.y, 1); 
                    }
                    else
                    {
                        rect.gameObject.transform.localScale -= Vector3.up * Speed * Time.deltaTime;
                        if (rect.localScale.y < finalAnchoredPos.y)
                            rect.gameObject.transform.localScale = new Vector3(rect.gameObject.transform.localScale.x, finalAnchoredPos.y, 1);
                    }

                    if (isIncreaseX)
                    {
                        rect.gameObject.transform.localScale += Vector3.right * Speed * Time.deltaTime;
                        if (rect.localScale.x > finalAnchoredPos.x)
                            rect.gameObject.transform.localScale = new Vector3(finalAnchoredPos.x, rect.gameObject.transform.localScale.y, 1);
                    }
                    else
                    {
                        rect.gameObject.transform.localScale -= Vector3.right * Speed * Time.deltaTime;
                        if (rect.localScale.x < finalAnchoredPos.x)
                            rect.gameObject.transform.localScale = new Vector3(finalAnchoredPos.x, rect.gameObject.transform.localScale.y, 1);
                    }

                    yield return null;
                }
            }
            else
            {
                isIncreaseX = finalAnchoredPos.x > rect.rect.width;
                isIncreaseY = finalAnchoredPos.y > rect.rect.height;

                while (rect.rect.width != finalAnchoredPos.x || rect.rect.height != finalAnchoredPos.y)
                {
                    if (isIncreaseY)
                    {
                        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rect.rect.height + Speed * Time.deltaTime);
                        if (rect.rect.height > finalAnchoredPos.y)
                            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, finalAnchoredPos.y);
                    }
                    else
                    {
                        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rect.rect.height - Speed * Time.deltaTime);
                        if (rect.rect.height < finalAnchoredPos.y)
                            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, finalAnchoredPos.y);
                    }

                    if (isIncreaseX)
                    {
                        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rect.rect.width + Speed * Time.deltaTime);
                        if (rect.rect.width > finalAnchoredPos.x)
                            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, finalAnchoredPos.x);
                    }
                    else
                    {
                        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rect.rect.width - Speed * Time.deltaTime);
                        if (rect.rect.width < finalAnchoredPos.x)
                            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, finalAnchoredPos.x);
                    }

                    yield return null;
                }
            }
            yield return null;

            if (action != null)
            {
                action.Invoke();
            }
        }
        #endregion
    }


    public class MiscUtils 
    {
        public static string[] uppercaseLetters = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public static Vector3[] GetPositionsInCircle(int numOfPoints, Vector3 centerPoint, float radius)
        {
            Vector3[] objPointsInCircle = new Vector3[numOfPoints];
            for (int i = 0; i < numOfPoints; i++)
            {

                /* Distance around the circle */
                var radians = 2 * Mathf.PI / numOfPoints * i;

                /* Get the vector direction */
                var vertrical = Mathf.Sin(radians);
                var horizontal = Mathf.Cos(radians);

                var spawnDir = new Vector3(horizontal, vertrical, 0);

                /* Get the spawn position */
                Vector3 spawnPos = centerPoint + spawnDir * radius; // Radius is just the distance away from the point

                objPointsInCircle[i] = spawnPos;
            }

            return objPointsInCircle;
        }
        public static float ValueToVolume(float value, float maxVolume)
        {
            return Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * (maxVolume - (-80f)) / 4f + maxVolume;
        }

        public static Transform[] GetChildren(Transform parent) 
        {
            int childCount = parent.childCount;
            Transform[] children = new Transform[childCount];

            for (int i = 0; i < children.Length; i++)
            {
                children[i] = parent.GetChild(i);
            }

            return children;
        }

        public static List<T> ArrayToList<T>(T[] array)
        {
            List<T> list = new List<T>();

            for (int i = 0; i < array.Length; i++)
            {
                list.Add(array[i]);
            }

            return list;
        }

        public static void MoveTo(MonoBehaviour behaviour, Transform objTransform, Vector3 destination, float speed, bool isLocal = false) 
        {
            behaviour.StartCoroutine (coroutine_MoveTo(objTransform, destination, speed, isLocal));
        }

        static IEnumerator coroutine_MoveTo(Transform objTransform, Vector3 destination, float speed, bool isLocal = false) 
        {
            Vector3 refV = Vector3.zero;
            Vector3 currentPos = Vector3.zero;
            if (isLocal)
            {
                currentPos = objTransform.localPosition;
                while (Mathf.Abs((objTransform.localPosition.x - destination.x)) > 0.01f)
                {
                    objTransform.transform.localPosition = Vector3.MoveTowards(objTransform.localPosition, destination, Time.deltaTime * speed);
                    yield return null;
                }
            }
            else
            {
                currentPos = objTransform.position;
                while (Mathf.Abs((objTransform.position.x - destination.x)) > 0.01f)
                {
                    objTransform.transform.position = Vector3.SmoothDamp(currentPos, destination, ref refV, speed);
                    yield return null;
                }
            }

            
        }

        /// <summary>
        /// Runs the action code after delay. If delay = 0, code with run after 1 frame.
        /// </summary>
        /// <param name="behaviour">The behaviour on which coroutine run. Use "this" in most cases</param>
        /// <param name="code">The code to run</param>
        /// <param name="delay">The time to wait</param>
        public static Coroutine DoWithDelay(MonoBehaviour behaviour, System.Action code, float delay = 0)
        {
            return behaviour.StartCoroutine(coroutine_doWithDelay(code, delay));
        }


        /// <summary>
        /// Runs the action code after delay. If delay = 0, code with run after 1 frame.
        /// </summary>
        /// <param name="behaviour">The behaviour on which coroutine run. Use "this" in most cases</param>
        /// <param name="code">The code to run</param>
        /// <param name="delay">The time to wait</param>
        public static Coroutine DoWhenDone(MonoBehaviour behaviour, System.Action code, System.Func<bool> predicate)
        {
            return behaviour.StartCoroutine(coroutine_doWhenDone(code, predicate));
        }

        /// <summary>
        /// Runs the action code after delay. If delay = 0, code with run after 1 frame.
        /// </summary>
        /// <param name="behaviour">The behaviour on which coroutine run. Use "this" in most cases</param>
        /// <param name="code">The code to run</param>
        /// <param name="delay">The time to wait</param>
        public static Coroutine DoRepeating(MonoBehaviour behaviour, System.Action code, float delay = 0)
        {
            return behaviour.StartCoroutine(coroutine_doRepeating(code, delay));
        }

        static IEnumerator coroutine_doWithDelay(System.Action code, float delay)
        {
            if (delay > 0)
            {
                yield return new WaitForSeconds(delay);
                code.Invoke();
            }
            else
            {
                yield return null;
                code.Invoke();
            }
        }

        static IEnumerator coroutine_doWhenDone(System.Action code, System.Func<bool> predicate)
        {
            yield return new WaitUntil(predicate);
            code.Invoke();
        }

        static IEnumerator coroutine_doRepeating(System.Action code, float delay)
        {
            while (true)
            {
                code.Invoke();
                yield return new WaitForSeconds(delay);
            }
        }

        /// <summary>
        /// Get all children of specific type. Non-component classes will return null
        /// </summary>
        /// <typeparam name="T">The type of component</typeparam>
        /// <param name="parent">Parent whose children will return</param>
        /// <returns>Children Objects of parent</returns>
        public static T[] GetChildren<T>(Transform parent) where T : class
        {
            T[] children = new T[parent.childCount];
            for (int i = 0; i < children.Length; i++)
            {
                if (typeof(T) == typeof(GameObject)) // for gameobject
                    children[i] = parent.GetChild(i).gameObject as T;
                else if (typeof(T) == typeof(Transform)) // for transform
                    children[i] = parent.GetChild(i).transform as T;
                else if (typeof(T) == typeof(MonoBehaviour)) // for any component
                {
                    children[i] = parent.GetChild(i).GetComponent<T>() as T;
                }
                else // return null for non-component types
                {
                    return null;
                }
            }
            return children;
        }

        public static byte CharToByte(char character)
        {
            byte b = (byte)(char.ToUpper(character) - 64);
            return b;
        }

        public static byte CharToByte(string character)
        {
            if (character == "" || string.IsNullOrEmpty(character))
                return 0;

            byte b = (byte)(char.ToUpper(character[0]) - 64);
            return b;
        }

        public static char ByteToChar(byte index)
        {
            if (index + 64 <= 64)
                return (char)0;

            return (char)(index + 64);
        }
    }

    public class PlayerPrefKeys 
    {
        public static string DATA_USERNAME = "1";
        public static string GUEST_USERNAME = "2";
        public static string MATCH_TYPE = "3";
        
    }
}