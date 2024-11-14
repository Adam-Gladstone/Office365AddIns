using System;

namespace REnvironmentControlLibrary.Models
{
    public class Param<T>
    {
        public Param(string name, bool required = true)
        {
            m_name = name;
            m_required = required;
            m_is_set = false;
        }

        private T m_value;
        private string m_name;
        private bool m_required;
        private bool m_is_set;

        public string Name { get { return m_name; } }
        public bool Required { get { return m_required; } }

        public T Value
        {
            get { return m_value; }
            set
            {
                m_value = value;
                m_is_set = true;
            }
        }

        public string GetParamValue(bool quoted = false)
        {
            if (!m_is_set)
                return string.Empty;

            string formattedValue = "";
            if (m_required == true)
            {
                if (m_value != null)
                {
                    if (m_value.GetType().IsEnum)
                    {
                        if (m_value.ToString() != "e_UNKNOWN")
                        {
                            int value = (int)Convert.ChangeType(m_value, typeof(int));
                            formattedValue = quoted ? $"{m_name} = '{value}'" : $"{m_name} = {value}";
                        }
                    }
                    else
                    {
                        formattedValue = quoted ? $"{m_name} = '{m_value}'" : $"{m_name} = {m_value}";
                    }
                }
                else
                {
                    // throw an exception: value is null but the type is required
                }
            }
            else
            {
                if (m_value != null)
                {
                    if (m_value.ToString() != "")
                    {
                        if (m_value.GetType().IsEnum)
                        {
                            if (m_value.ToString() != "e_UNKNOWN")
                            {
                                int value = (int)Convert.ChangeType(m_value, typeof(int));
                                formattedValue = quoted ? $"{m_name} = '{value}'" : $"{m_name} = {value}";
                            }
                        }
                        else
                        {
                            formattedValue = quoted ? $"{m_name} = '{m_value}'" : $"{m_name} = {m_value}";
                        }
                    }
                }
            }
            return formattedValue;
        }
    }
}
